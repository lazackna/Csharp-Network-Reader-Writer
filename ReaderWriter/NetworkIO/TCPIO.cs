using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using Lazackna.NetworkIO.Abstractions;

namespace Lazackna.NetworkIO
{
    public class TCPIO : StreamIO
    {
        protected TcpClient _tcpClient;

        protected const int _lengthBufferSize = 4;

        public TCPIO(TcpClient tcpclient) : base(tcpclient.GetStream())
        {
            _tcpClient = tcpclient;
        }

        public override byte[] Read()
        {
            byte[] length = new byte[_lengthBufferSize];
            _stream.Read(length, 0, _lengthBufferSize);

            int size = BitConverter.ToInt32(length, 0);

            byte[] received = new byte[size];

            int bytesRead = 0;
            while (bytesRead < size)
            {
                int read = _stream.Read(received, bytesRead, received.Length - bytesRead);
                bytesRead += read;
            }

            return received;
        }

        public override async Task<byte[]> ReadAsync()
        {
            byte[] length = new byte[_lengthBufferSize];
            await _stream.ReadAsync(length, 0, _lengthBufferSize);

            int size = BitConverter.ToInt32(length, 0);

            byte[] received = new byte[size];

            int bytesRead = 0;
            while (bytesRead < size)
            {
                int read = await _stream.ReadAsync(received, bytesRead, received.Length - bytesRead);
                bytesRead += read;
            }

            return received;
        }

        public override void Write(byte[] message)
        {
            byte[] wrappedMessage = WrapMessage(message);
            _stream.Write(wrappedMessage, 0, wrappedMessage.Length);
            _stream.Flush();
        }

        public override async Task WriteAsync(byte[] message)
        {
            byte[] wrappedMessage = WrapMessage(message);
            await _stream.WriteAsync(wrappedMessage, 0, wrappedMessage.Length);
            await _stream.FlushAsync();
        }

        protected byte[] WrapMessage(byte[] message)
        {
            // Get the length prefix for the message
            byte[] lengthPrefix = BitConverter.GetBytes(message.Length);

            // Concatenate the length prefix and the message
            byte[] ret = new byte[lengthPrefix.Length + message.Length];
            lengthPrefix.CopyTo(ret, 0);
            message.CopyTo(ret, lengthPrefix.Length);
            return ret;
        }
    }
}
