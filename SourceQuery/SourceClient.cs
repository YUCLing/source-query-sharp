using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SourceQuery
{
	public class SourceClient
	{
		private readonly UdpClient client;

		public SourceClient(UdpClient client)
		{
			this.client = client;
		}

		public SourceClient(string ip, int port = 27015)
		{
			client = new UdpClient(ip, port);
		}

		public SourceInfo GetServerInfo()
		{
			client.Send(Packets.A2S_INFO, Packets.A2S_INFO.Length);
			IPEndPoint remoteEP = null;
			byte[] array;
			do
			{
				array = client.Receive(ref remoteEP);
			}
			while (array[4] != 73);
			int num = 5;
			byte protocol = array[num];
			num++;
			string str = "";
			num += Utils.ReadString(array, ref str, num) + 1;
			string str2 = "";
			num += Utils.ReadString(array, ref str2, num) + 1;
			string str3 = "";
			num += Utils.ReadString(array, ref str3, num) + 1;
			string str4 = "";
			num += Utils.ReadString(array, ref str4, num) + 1;
			short num2 = BitConverter.ToInt16(array, num);
			num += 2;
			int players = array[num];
			num++;
			int maxplayers = array[num];
			num++;
			int bots = array[num];
			num++;
			string @string = Encoding.UTF8.GetString(array.Skip(num).Take(1).ToArray());
			num++;
			string string2 = Encoding.UTF8.GetString(array.Skip(num).Take(1).ToArray());
			num++;
			bool visible = array[num] == 0;
			num++;
			bool vac = array[num] == 1;
			num++;
			string str5 = "";
			Utils.ReadString(array, ref str5, num);
			return new SourceInfo(protocol, str, str2, str3, str4, num2, players, maxplayers, bots, @string, string2, visible, vac, str5);
		}

		public Player[] GetPlayers()
		{
			client.Send(Packets.A2S_PLAYER_CHALLENGE, Packets.A2S_PLAYER_CHALLENGE.Length);
			IPEndPoint remoteEP = null;
			byte[] array;
			do
			{
				array = client.Receive(ref remoteEP);
			}
			while (array[4] != 65);
			byte[] array2 = array.Skip(5).Take(4).ToArray();
			byte[] array3 = Utils.ConcatBytes(Packets.A2S_PLAYER, array2);
			client.Send(array3, array3.Length);
			do
			{
				array = client.Receive(ref remoteEP);
			}
			while (array[4] != 68);
			int num = 5;
			int num2 = array[num];
			num++;
			Player[] array4 = new Player[num2];
			for (int i = 0; i < num2; i++)
			{
				int index = array[num];
				num++;
				string str = "";
				num += Utils.ReadString(array, ref str, num) + 1;
				long score = BitConverter.ToInt32(array, num);
				num += 4;
				float duration = BitConverter.ToSingle(array, num);
				num += 4;
				array4[i] = new Player(index, str, score, duration);
			}
			return array4;
		}
	}

}
