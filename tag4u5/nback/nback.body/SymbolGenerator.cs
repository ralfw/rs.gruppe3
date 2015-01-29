using System;
using nback.contracts;

namespace nback.body
{
	class SymbolGenerator
	{
		private int n, l;

		// Added l to the param list
		public char Generate(int n, int l) {
			this.l = l;
			this.n = n;
			return (char)((int)'A' + this.l--);
		}
			
		// Added a second function to generate the next symbol
		public char Generate() {
			return (char)((int)'A' + this.l--);
		}
	}
}