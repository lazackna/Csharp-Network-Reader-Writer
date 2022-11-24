using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lazackna.NetworkIO.UDP.Abstractions
{
    public class UdpBase
    {
        protected System.Net.Sockets.UdpClient Client;

        protected UdpBase()
        {
            Client = new System.Net.Sockets.UdpClient();
        }

        public async Task<ReceivedUdpData> ReceiveAsync()
        {
            var result = await Client.ReceiveAsync();

            return new ReceivedUdpData()
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
}
