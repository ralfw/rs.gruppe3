using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class AST {
		public Node Root;
	}

	abstract class Node {
		public Node Left, Right;
	}

	class OperatorNode : Node {
		public Operators Op;
	}

	class OperandNode : Node {
		public int Value;
	}
}
