using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lazackna.NetworkIO.Interfaces;

namespace Lazackna.NetworkIO.Abstractions
{
    /// <summary>
    /// Base class for all Stream based IO
    /// </summary>
    public abstract class StreamIO : INetworkStreamIO
    {
        protected Stream _stream;

        protected StreamIO(Stream stream)
        {
            _stream = stream;
        }

        public abstract byte[] Read();

        public abstract Task<byte[]> ReadAsync();

        public abstract void Write(byte[] data);

        public abstract Task WriteAsync(byte[] data);
    }
}
