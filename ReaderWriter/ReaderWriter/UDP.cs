using ReaderWriter.util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ReaderWriter.UDP
{
	public struct ReceivedData
    {
		public IPEndPoint Sender;
		public byte[] Data;
    }
	public abstract class UdpBase : IDisposable
	{
		protected System.Net.Sockets.UdpClient Client;

		protected UdpBase()
        {
			Client = new System.Net.Sockets.UdpClient();
        }

		public async Task<ReceivedData> ReceiveAsync()
        {
			var result = await Client.ReceiveAsync();

			return new ReceivedData()
			{
				Data = result.Buffer,
				Sender = result.RemoteEndPoint
			};
        }

        public byte[] Receive(ref IPEndPoint endpoint)
        {
            return Client.Receive(ref endpoint);
        }

		public virtual void Dispose()
        {
			Client.Dispose();
        }
    }

	public class UdpListener : UdpBase
    {
		private IPEndPoint _listenOnAddress;

		public UdpListener() : this(new IPEndPoint(IPAddress.Any, 9999))
        {

        }

		public UdpListener(IPEndPoint endpoint)
        {
			_listenOnAddress = endpoint;
			Client = new System.Net.Sockets.UdpClient(_listenOnAddress);
        }

		public void Reply(byte[] data, IPEndPoint endpoint)
        {
			Client.Send(data, data.Length, endpoint);
        }

		public async Task ReplyAsync(byte[] data, IPEndPoint endpoint)
        {
			await Client.SendAsync(data, data.Length, endpoint);
        }
    }

	public class UdpClient : UdpBase
    {
        private UdpClient() { }

        public static UdpClient ConnectTo(string hostname, int port)
        {
            var connection = new UdpClient();
            connection.Client.Connect(hostname, port);
            return connection;
        }

        public void Send(byte[] data)
        {
            Client.Send(data, data.Length);
        }

        public async Task SendAsync(byte[] data)
        {
            await Client.SendAsync(data, data.Length);
        }
    }
}
