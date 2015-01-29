using System;
using nback.contracts;

namespace nback.body
{
	class SymbolGenerator
	{
		private int n, l;

		// Added l to the param list
		public char Start_symbol_series(int n, int l) {
			this.l = l;
			this.n = n;
			return 'A' + this.l--;
		}
			
		// Added a second function to generate the next symbol
		public char Get_next_symbol_in_series() {
			return 'A' + this.l--;
		}
	}
}