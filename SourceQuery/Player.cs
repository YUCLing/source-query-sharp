using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceQuery
{
	public class Player
	{
		public readonly int Index;

		public readonly string Name;

		public readonly long Score;

		public readonly float Duration;

		internal Player(int index, string name, long score, float duration)
		{
			Index = index;
			Name = name;
			Score = score;
			Duration = duration;
		}
	}

}
