
using System;
using System.Net;

using System.Text;

using Lazackna.NetworkIO.UDP;

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
			//TcpListener listener = new TcpListener(IPAddress.Any, 8888);
			//listener.Start();
			//while(true)
			//{
			//	TCP tcp = new TCP(listener.AcceptTcpClient());

			//	tcp.WriteData(Encoding.ASCII.GetBytes("Hello world!"));
			//	byte[] data = tcp.ReadData();
			//	Console.WriteLine(Encoding.ASCII.GetString(data));
			//	tcp.Dispose();
			//}

			UdpListener listener = new UdpListener(new IPEndPoint(IPAddress.Any, 8888));
			while(true)
            {
				var received = listener.ReceiveAsync().Result;

				Console.WriteLine(Encoding.ASCII.GetString(received.Data));

				listener.Reply(Encoding.ASCII.GetBytes("Hello from client"), received.Sender);
			}
		}
	}
}
