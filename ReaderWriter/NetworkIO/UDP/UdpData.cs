using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lazackna.NetworkIO.UDP
{
    public struct ReceivedUdpData
    {
        public IPEndPoint Sender;
        public byte[] Data;
    }
}
