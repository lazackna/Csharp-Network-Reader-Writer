using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazackna.NetworkIO.Interfaces
{
    public interface INetworkStreamIO
    {
        byte[] Read();
        Task<byte[]> ReadAsync();
        void Write(byte[] data);
        Task WriteAsync(byte[] data);
    }
}
