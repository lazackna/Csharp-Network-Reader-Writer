using ReaderWriter.util;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ReaderWriter
{
	public class UDP : IDisposable
	{
		private UdpClient client;
		
		public UDP(string hostname, int port)
		{
			client = new UdpClient(hostname, port);
			//readWrite = new ReadWrite(client.GetStream());
			
			
		}

		public UDP(UdpClient client)
		{
			this.client = client;
			//readWrite = new ReadWrite(client.GetStream());
		}

		public void WriteData(byte[] data)
		{
			byte[] toSend = MessageWrapper.WrapMessage(data);
			client.Send(toSend, toSend.Length);
		}

		public byte[] ReadData() {

			return null;
		}

		public void Dispose()
		{ 
			client.Close();
			client.Dispose();
		}
	}
}
