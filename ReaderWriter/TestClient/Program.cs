using ReaderWriter;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//TcpClient client = new TcpClient("127.0.0.1", 8888);
			//TCP tcp = new TCP(client);
			//byte[] data = tcp.ReadData();
			//Console.WriteLine(Encoding.ASCII.GetString(data));
			//tcp.WriteData(Encoding.ASCII.GetBytes("Hello from client!"));

			ReaderWriter.UDP.UdpClient client = ReaderWriter.UDP.UdpClient.ConnectTo("127.0.0.1", 8888);

			while(true)
            {
				client.Send(Encoding.ASCII.GetBytes("Hello server"));

				IPEndPoint endpoint = null;
				byte[] receivedData = client.Receive(ref endpoint);

				Console.WriteLine($"Received {Encoding.ASCII.GetString(receivedData)} from {endpoint.Address}");
			}
			Console.ReadLine();
        }
	}
}
