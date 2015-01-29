using System;

namespace nback.contracts
{

	public struct GameReport {
		public string Name;
		public DateTime StartedAt;
		public int PercentRecognized;
		public int PercentNotRecognized;
		public char[] Symbols;
	}
}
