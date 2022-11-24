using System.Net;
using Lazackna.NetworkIO.UDP.Abstractions;

namespace Lazackna.NetworkIO.UDP
{
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
}
