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
				TcpClient client = listener.AcceptTcpClient();
				TCP tcp = new TCP(client.GetStream());

				tcp.Write(Encoding.ASCII.GetBytes("Hello world!"));
				byte[] data = tcp.Read();
				Console.WriteLine(Encoding.ASCII.GetString(data));
				tcp.Dispose();
				client.Close();
				client.Dispose();
			}
		}
	}
}
