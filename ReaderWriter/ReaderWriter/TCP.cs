using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ReaderWriter
{
	public class TCP : IDisposable
	{
		private TcpClient client;
		private ReadWrite readWrite;
		public TCP(string hostname, int port)
		{
			client = new TcpClient(hostname, port);
			readWrite = new ReadWrite(client.GetStream());
		}

		public TCP(TcpClient client)
		{
			this.client = client;
			readWrite = new ReadWrite(client.GetStream());
		}

		public void WriteData(byte[] data) => readWrite.Write(data);

		public byte[] ReadData() => readWrite.Read();

		public void Dispose()
		{
			readWrite.Dispose();
			client.Close();
			client.Dispose();
		}
	}
}
