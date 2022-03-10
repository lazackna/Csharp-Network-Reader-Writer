using System.Net;
using System.Collections.Generic;
using System.Text;
using System;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using ReaderWriter.util;
namespace ReaderWriter
{
	public class TCP : IDisposable
	{
		private NetworkStream stream;
		
		public TCP(NetworkStream stream) => this.stream = stream;

		public void Write(byte[] message)
		{
			try
			{
				stream.Write(MessageWrapper.WrapMessage(message));
				stream.Flush();
			} catch (IOException e)
			{
				Debug.WriteLine(e.Message);
			} catch (NotSupportedException e)
			{
				Debug.WriteLine(e.Message);
			}
		}

		public byte[] Read()
		{
			byte[] length = new byte[4];
			this.stream.Read(length, 0, 4);

			int size = BitConverter.ToInt32(length);

			byte[] received = new byte[size];

			int bytesRead = 0;
			while (bytesRead < size)
			{
				int read = stream.Read(received, bytesRead, received.Length - bytesRead);
				bytesRead += read;
			}

			return received;
		}

		public void Dispose()
		{
			stream.Close();
			stream.Dispose();
		}
	}
}
