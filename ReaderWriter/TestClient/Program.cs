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
			TCP tcp = new TCP(client);
			byte[] data = tcp.ReadData();
			Console.WriteLine(Encoding.ASCII.GetString(data));
			tcp.WriteData(Encoding.ASCII.GetBytes("Hello from client!"));
		}
	}
}
