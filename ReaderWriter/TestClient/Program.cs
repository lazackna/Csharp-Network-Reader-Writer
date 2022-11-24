using Lazackna.NetworkIO.UDP;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UdpClient = Lazackna.NetworkIO.UDP.UdpClient;

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

			UdpClient client = UdpClient.ConnectTo("127.0.0.1", 8888);
			long i = 0;
			while(true)
            {
				client.Send(Encoding.ASCII.GetBytes($"Hello server {i}"));

				IPEndPoint endpoint = null;
				byte[] receivedData = client.Receive(ref endpoint);

				Console.WriteLine($"Received {Encoding.ASCII.GetString(receivedData)} from {endpoint.Address}");
				i++;
			}
			Console.ReadLine();
        }
	}
}
