using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceQuery
{
	public class SourceInfo
	{
		public readonly byte Protocol;

		public readonly string Name;

		public readonly string Map;

		public readonly string Folder;

		public readonly string Game;

		public readonly short GameID;

		public readonly int Players;

		public readonly int MaxPlayers;

		public readonly int Bots;

		public readonly string ServerType;

		public readonly string Environment;

		public readonly bool Visibility;

		public readonly bool VAC;

		public readonly string Version;

		internal SourceInfo(byte protocol, string name, string map, string folder, string game, short gameid, int players, int maxplayers, int bots, string type, string env, bool visible, bool vac, string version)
		{
			Protocol = protocol;
			Name = name;
			Map = map;
			Folder = folder;
			Game = game;
			GameID = gameid;
			Players = players;
			MaxPlayers = maxplayers;
			Bots = bots;
			ServerType = type;
			Environment = env;
			Visibility = visible;
			VAC = vac;
			Version = version;
		}
	}

}
