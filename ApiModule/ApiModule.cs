using System;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ApiModule
{
	// Token: 0x02000002 RID: 2
	public class ApiModule
	{
        private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        public static bool namedPipeExist(string pipeName)
		{
			bool result;
			try
			{
				if (!WaitNamedPipe(Path.GetFullPath(string.Format("\\\\.\\pipe\\{0}", pipeName)), 0))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 0)
					{
						result = false;
						return result;
					}
					if (lastWin32Error == 2)
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool WaitNamedPipe(string name, int timeout);
		public static void ExecuteScript(string Script)
		{
            try
            {
                using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", "462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F", PipeDirection.Out))
                {
                    namedPipeClientStream.Connect();
                    using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999))
                    {
                        streamWriter.Write(Script);
                        streamWriter.Dispose();
                    }
                    namedPipeClientStream.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!\n" + ex, "NamedPipeDoesntExist", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
		}
		public static bool DownloadDLL()
		{
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string[] array = wc.DownloadString("https://pastebin.com/raw/X6VePTFn").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			wc.DownloadFile(array[1], "ApiModuleDLL.dll");
			return File.Exists("ApiModuleDLL.dll");
		}
        public static bool CheckUpdate()
		{
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string[] array = wc.DownloadString("https://pastebin.com/raw/X6VePTFn").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\\\ApiModule", true);
			if (registryKey == null)
			{
				registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\ApiModule");
				registryKey.SetValue("Ver", "0");
			}
			if (registryKey.GetValue("Ver").ToString() != array[0])
			{
				registryKey.SetValue("Ver", array[0]);
				return true;
			}
			return false;
		}
		public void RunRemoteSpy()
		{
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ExecuteScript(wc.DownloadString("https://pastebin.com/raw/QeVmYCk1"));
		}
		private void InjectDLL()
		{

		}
		public void LaunchExploit()
		{
			if (namedPipeExist("462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F"))
			{
				MessageBox.Show("Already Attached!", "NamedPipeExist!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (!CheckUpdate() && File.Exists("ApiModuleDLL.dll"))
			{
				this.InjectDLL();
				return;
			}
			if (DownloadDLL())
			{
				this.InjectDLL();
				return;
			}
			MessageBox.Show("Cant download the lastest version!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		private static WebClient wc = new WebClient();
	}
}
