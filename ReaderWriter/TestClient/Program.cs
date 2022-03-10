using ReaderWriter;
using System;
using System.Net.Sockets;
using System.Text;

namespace TestClient
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpClient client = new TcpClient("127.0.0.1", 8888);
			TCP tcp = new TCP(client.GetStream());
			byte[] data = tcp.Read();
			Console.WriteLine(Encoding.ASCII.GetString(data));
			tcp.Write(Encoding.ASCII.GetBytes("Hello from client!"));
		}
	}
}
