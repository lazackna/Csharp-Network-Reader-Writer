using System;
using System.Collections.Generic;
using System.Text;

namespace ReaderWriter.util
{
	public class MessageWrapper
	{
		public static byte[] WrapMessage(byte[] message)
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
