using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Updater
{
    public partial class MainFrm : Form
    {
        private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        string appName = Path.GetFileNameWithoutExtension(Program.baseApp);
        string rndFileName = AppDomain.CurrentDomain.BaseDirectory + RandomString(18) + ".tmp";
        string rndFile = AppDomain.CurrentDomain.BaseDirectory + RandomString(18) + ".tmp";
        public MainFrm()
        {
            InitializeComponent();
            if (Program.mapmode)
            {
                MultiUpdater();
            }
            else
            {
                Updater();
            }
        }
        private async void Updater()
        {
            if (File.Exists(Program.baseApp))
            {
                try
                {
                    Console.WriteLine("Begin backup process...");
                    File.Move(Program.baseApp, rndFileName);
                    Console.WriteLine("Moved " + Program.baseApp + " to " + rndFileName);
                    Console.WriteLine("Done");
                    if (Program.urlMode)
                    {
                        Console.WriteLine("Url mode enabled, downloading file...");
                        using (WebClient wc = new WebClient())
                        {
                            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            wc.DownloadFileCompleted += wc_DFC;
                            Console.WriteLine("Begin to download " + Program.newApp);
                            wc.DownloadFileAsync(new System.Uri(Program.newApp), rndFile);
                            wc.Dispose();
                        }
                    }
                    else if (File.Exists(Program.newApp))
                    {
                        Console.WriteLine("Replacing file...");
                        foreach (var proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appName)))
                        {
                            proc.Kill();
                            Console.WriteLine("Killed " + appName);
                        }
                        await Task.Delay(100);
                        File.Move(Program.newApp, Program.baseApp);
                        Console.WriteLine("Moved " + Program.newApp + " to " + Program.baseApp);
                        Console.WriteLine("Deleting old file...");
                        await Task.Delay(100);
                        File.Delete(rndFileName);
                        Console.WriteLine("Deleted " + rndFileName);
                        Console.WriteLine("Update sucess...");
                        if (Program.relaunch)
                            LaunchApp();
                        Environment.Exit(0);
                    }
                    else
                    {
                        await Task.Delay(100);
                        File.Move(rndFileName, Program.baseApp);
                        Console.WriteLine("Failed to update app, restoring original app. Logs are below...");
                        //File.Delete(rndFileName);
                        Console.WriteLine("New file does not exist, nothing to update...");
                        await Task.Delay(100);
                        if (Program.relaunch)
                            LaunchApp();
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    await Task.Delay(100);
                    File.Move(rndFileName, Program.baseApp);
                    Console.WriteLine("Failed to update app, restoring original app. Logs are below...");
                    Console.WriteLine(ex);
                    MessageBox.Show("Failed to update app so i restored original app. Logs are below...\n" + ex, "TsuUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (Program.relaunch)
                        LaunchApp();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Main file does not exist, nothing to update...");
                await Task.Delay(100);
                if (Program.relaunch)
                    LaunchApp();
                Environment.Exit(0);
            }
        }

        private async void MultiUpdater()
        {
            for (var i = 0;  i < Program.baseApps.ToArray().Length; i += 1)
            {
                if (File.Exists(Program.baseApps.ToArray()[i]))
                {
                    appName = Path.GetFileNameWithoutExtension(Program.baseApps.ToArray()[i]);
                    rndFileName = AppDomain.CurrentDomain.BaseDirectory + RandomString(18) + ".tmp";
                    rndFile = AppDomain.CurrentDomain.BaseDirectory + RandomString(18) + ".tmp";
                    try
                    {
                        Console.WriteLine("Begin backup process...");
                        File.Move(Program.baseApps.ToArray()[i], rndFileName);
                        Console.WriteLine("Moved " + Program.baseApps.ToArray()[i] + " to " + rndFileName);
                        Console.WriteLine("Done");
                        /*if (Program.urlMode)
                        {
                            Console.WriteLine("Url mode enabled, downloading file...");
                            using (WebClient wc = new WebClient())
                            {
                                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                                ServicePointManager.Expect100Continue = true;
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                wc.DownloadFileCompleted += wc_DFC;
                                Console.WriteLine("Begin to download " + Program.newApp);
                                wc.DownloadFileAsync(new System.Uri(Program.newApp), rndFile);
                                wc.Dispose();
                            }
                        }
                        else */
                        if (File.Exists(Program.newApps.ToArray()[i]))
                        {
                            Console.WriteLine("Replacing file...");
                            foreach (var proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appName)))
                            {
                                proc.Kill();
                                Console.WriteLine("Killed " + appName);
                            }
                            await Task.Delay(100);
                            File.Move(Program.newApps.ToArray()[i], Program.baseApps.ToArray()[1]);
                            Console.WriteLine("Moved " + Program.newApps.ToArray()[1] + " to " + Program.baseApps.ToArray()[1]);
                            Console.WriteLine("Deleting old file...");
                            await Task.Delay(100);
                            File.Delete(rndFileName);
                            Console.WriteLine("Deleted " + rndFileName);
                            Console.WriteLine("Update sucess...");
                        }
                        else
                        {
                            await Task.Delay(100);
                            File.Move(rndFileName, Program.baseApps.ToArray()[i]);
                            Console.WriteLine("Failed to update app, restoring original app. Logs are below...");
                            //File.Delete(rndFileName);
                            Console.WriteLine("New file does not exist, nothing to update...");
                        }
                    }
                    catch (Exception ex)
                    {
                        await Task.Delay(100);
                        File.Move(rndFileName, Program.baseApps.ToArray()[i]);
                        Console.WriteLine("Failed to update app, restoring original app. Logs are below...");
                        Console.WriteLine(ex);
                        MessageBox.Show("Failed to update app so i restored original app. Logs are below...\n" + ex, "TsuUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine("Main file does not exist, nothing to update...");
                }
            }
            Environment.Exit(0);
        }
        private async void wc_DFC(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Downloaded " + rndFile + ". Replacing file");
            if (new FileInfo(rndFile).Length != 0)
            {
                try
                {
                    foreach (var proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(appName)))
                    {
                        proc.Kill();
                        Console.WriteLine("Killed " + appName);
                    }
                    File.Move(rndFile, Program.baseApp);
                    Console.WriteLine("Moved " + rndFile + " to " + Program.baseApp);
                    await Task.Delay(100);
                    File.Delete(rndFileName);
                    Console.WriteLine("Deleted " + rndFileName);
                    await Task.Delay(100);
                    File.Delete(rndFile);
                    Console.WriteLine("Deleted " + rndFile);
                    Console.WriteLine("Update sucess...");
                    await Task.Delay(100);
                    if (Program.relaunch)
                        LaunchApp();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to update app, restoring original app. Logs are below...");
                    Console.WriteLine(ex);
                    await Task.Delay(100);
                    File.Move(rndFileName, Program.baseApp);
                    await Task.Delay(100);
                    File.Delete(rndFile);
                    MessageBox.Show("Failed to update app so i reverted update.... Logs are below...\n" + ex, "TsuUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await Task.Delay(100);
                    if (Program.relaunch)
                        LaunchApp();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Downloaded file size is 0, restoring original app...");
                File.Move(rndFileName, Program.baseApp);
                await Task.Delay(100);
                File.Delete(rndFile);
                await Task.Delay(100);
                MessageBox.Show("Failed to update app so i reverted update....", "TsuUpdater", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                if (Program.relaunch)
                    LaunchApp();
                Environment.Exit(0);
            }
        }
        private void LaunchApp()
        {
            Process.Start(Program.baseApp);
        }
        internal static readonly char[] chars =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public static string RandomString(int size)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }
            return result.ToString();
        }
        private void UserControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
