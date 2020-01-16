using System;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace TsuSploit.ExternalAPI // External API written by me (not released standalone)
{
    class KrnlAPI
    {
		public static void pipeshit(string script)
		{
			using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", "krnlpipe", PipeDirection.Out))
			{
				namedPipeClientStream.Connect();
				if (namedPipeClientStream.IsConnected)
				{
					StreamWriter streamWriter = new StreamWriter(namedPipeClientStream, Encoding.Default, 999999);
					streamWriter.Write(script);
					streamWriter.Dispose();
				}
			}
		}
		public static bool Pipe(string script)
		{
			if (Directory.GetFiles("\\\\.\\pipe\\").Contains("\\\\.\\pipe\\krnlpipe"))
			{
				pipeshit(script);
				return true;
			}
			else
				return false;
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool WaitNamedPipe(string name, int timeout);
		public static bool isKrnlInjected()
		{
			return Directory.GetFiles("\\\\.\\pipe\\").Contains("\\\\.\\pipe\\krnlpipe");
		}
	}
}
