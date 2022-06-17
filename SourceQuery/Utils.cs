using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceQuery
{
	internal static class Utils
	{
		public static byte[] ConcatBytes(params byte[][] bytes)
		{
			List<byte> list = new List<byte>();
			foreach (byte[] collection in bytes)
			{
				list.AddRange(collection);
			}
			return list.ToArray();
		}

		public static int ReadString(byte[] byt, ref string str, int position = 0)
		{
			int num = 0;
			List<byte> list = new List<byte>();
			for (int i = position; i < byt.Length; i++)
			{
				byte b = byt[i];
				if (b == 0)
				{
					break;
				}
				list.Add(b);
				num++;
			}
			str = Encoding.UTF8.GetString(list.ToArray());
			return num;
		}
	}
}
