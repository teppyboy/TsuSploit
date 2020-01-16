using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Updater
{
    static class Program
    {
        private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Argument 1: " + args[0]);
                try
                {
                    if (args[1] != null)
                    {
                        Console.WriteLine("Argument 2: " + args[1]);
                    }
                }
                catch
                {
                    Console.WriteLine("No argument 2...");
                }
                try
                {
                    if (args[2] != null)
                    {
                        Console.WriteLine("Argument 3: " + args[2]);
                        if (args[2].Contains("-relaunch"))
                        {
                            relaunch = true;
                            relaunchBaseFile = args[2].Remove(0, 10);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("No argument 3...");
                }
                if (args[0].Contains("-baseApp.") || args[0].Contains("-mapper.") || args[0].Contains("-mapperFromUrl."))
                {
                    if (args[0].Contains("-baseApp.") && (args[1].Contains("-newApp.") || args[1].Contains("-newfromUrl.")))
                    {
                        baseApp = args[0].Remove(0, 9);
                        if (args[1].Contains("-newfromUrl."))
                        {
                            urlMode = true;
                            newApp = args[1].Remove(0, 12);
                        }
                        else
                        {
                            newApp = args[1].Remove(0, 8);
                        }
                    }
                    else if (args[0].Contains("-mapper."))
                    {
                        /*
                        MessageBox.Show("Disabled for now, sorry!", "Updater");
                        Environment.Exit(0);
                        */
                        mapmode = true;
                        var file = args[0].Remove(0, 8);
                        if (File.Exists(file))
                        {
                            var lines = File.ReadAllLines(file);
                            for (var i = 0; i < lines.Length; i += 1)
                            {
                                var line = lines[i];
                                if (line.Contains("-base."))
                                {
                                    baseApps.Add(line.Remove(0, 6));
                                }
                                else if (line.Contains("-new."))
                                {
                                    newApps.Add(line.Remove(0, 5));
                                }
                            }
                            Console.WriteLine("baseApps count: " + baseApps.ToArray().Length.ToString());
                            Console.WriteLine("newApps count: " + newApps.ToArray().Length.ToString());
                            for (var i = 0; i < baseApps.ToArray().Length; i += 1)
                            {
                                Console.WriteLine($"Base app [{i.ToString()}]: {baseApps.ToArray()[i]}");
                            }
                            for (var i = 0; i < newApps.ToArray().Length; i += 1)
                            {
                                Console.WriteLine($"New app [{i.ToString()}]: {newApps.ToArray()[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Map file not found...");
                            Environment.Exit(0);
                        }
                    }
                    else if (args[0].Contains("-mapperFromUrl."))
                    {
                        /*
                        MessageBox.Show("Disabled for now, sorry!", "Updater");
                        Environment.Exit(0);
                        */
                        mapmodeUrl = true;
                        var fileUrl = args[0].Remove(0, 16);
                        try
                        {
                            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
                                wc.DownloadStringAsync(new Uri(fileUrl));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Download mapper failed...");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invaild argument...");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Invaild argument...");
                    Environment.Exit(0);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrm());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error.");
                Console.WriteLine(ex);
                Environment.Exit(0);
            }
        }

        private static void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string analyzeStr = e.Result;
            var lines = analyzeStr.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i];
                if (line.Contains("-base."))
                {
                    baseApps.Add(line.Remove(0, 6));
                }
                else if (line.Contains("-new."))
                {
                    newApps.Add(line.Remove(0, 5));
                }
            }
            Console.WriteLine("baseApps count: " + baseApps.ToArray().Length.ToString());
            Console.WriteLine("newApps count: " + newApps.ToArray().Length.ToString());
            for (var i = 0; i < baseApps.ToArray().Length; i += 1)
            {
                Console.WriteLine($"Base app [{i.ToString()}]: {baseApps.ToArray()[i]}");
            }
            for (var i = 0; i < newApps.ToArray().Length; i += 1)
            {
                Console.WriteLine($"New app [{i.ToString()}]: {newApps.ToArray()[i]}");
            }
        }

        public static string baseApp, newApp, relaunchBaseFile;
        public static List<string> baseApps = new List<string>();
        public static List<string> newApps = new List<string>();
        public static bool urlMode, relaunch, mapmode, mapmodeUrl;
    }
}
