using ReaderWriter;
using System;
using System.Net;
using System.Net.Sockets;
using ReaderWriter;
using System.Text;

namespace TestServer
{
	class Program
	{

		static void Main(string[] args)
		{
			new Program();
		}

		public Program()
		{
			TcpListener listener = new TcpListener(IPAddress.Any, 8888);
			listener.Start();
			while(true)
			{
				TCP tcp = new TCP(listener.AcceptTcpClient());
			
				tcp.WriteData(Encoding.ASCII.GetBytes("Hello world!"));
				byte[] data = tcp.ReadData();
				Console.WriteLine(Encoding.ASCII.GetString(data));
				tcp.Dispose();
			}
		}
	}
}
