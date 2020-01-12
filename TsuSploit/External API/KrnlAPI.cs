using System;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace TsuSploit.External_API //Sorry Ice Bear but i have to do this...
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
			return NamedPipeExist("krnlpipe");
		}
		private static bool NamedPipeExist(string pipeName)
		{
			try
			{
				if (!WaitNamedPipe($"\\\\.\\pipe\\{pipeName}", 0))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 0)
					{
						return false;
					}
					if (lastWin32Error == 2)
					{
						return false;
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
