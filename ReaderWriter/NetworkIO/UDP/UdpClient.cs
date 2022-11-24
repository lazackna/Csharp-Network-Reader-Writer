using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lazackna.NetworkIO.UDP.Abstractions;

namespace Lazackna.NetworkIO.UDP
{
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
