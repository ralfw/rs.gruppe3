using System;
using nback.contracts;

namespace nback.body
{
	class SymbolGenerator
	{
		private int n, l;

		public SymbolGenerator(int n, int l) {
			this.n = n;
			this.l = l;
		}

		//TODO: Generate symbols in a non-trivial way
		public char Generate() {
			return (char)((int)'A' + this.l--);
		}
	}
}