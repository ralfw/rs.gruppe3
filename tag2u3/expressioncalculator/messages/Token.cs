using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	abstract class Token {}

	class OperandToken : Token {
		public int Value;
	}

	class OperatorToken : Token {
		public Operators Op;
	}

}
