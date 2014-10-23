using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class ListEvaluator : IEvaluator {
		public void Eval(AST expression, Action<int> onResult, Action<string> onError) {
			Errorhandling.Try (
				() => {
					var result = Eval (expression.Ops, expression.Operands);
					onResult (result);
				},
				onError);
		}

		int Eval (IEnumerable<Operators> ops, IEnumerable<int> operands) {
			var valueStack = Stack_operands (operands);
			return Apply_operators (ops, valueStack);
		}
			
		Stack<int> Stack_operands(IEnumerable<int> operands) {
			return new Stack<int> (operands.Reverse ());
		}
			
		int Apply_operators(IEnumerable<Operators> ops, Stack<int> operands) {
			if (!ops.Any ()) return operands.Pop ();

			Apply_operator (ops.First(), operands);
			return Apply_operators (ops.Skip (1), operands);
		}

		private void Apply_operator(Operators op, Stack<int> operands) {
			var left = operands.Pop ();
			var right = operands.Pop ();
			var result = Execute (op, left, right);
			operands.Push (result);
		}

		private int Execute(Operators op, int leftValue, int rightValue) {
			switch (op) {
			case Operators.Add:
				return leftValue + rightValue;
			case Operators.Substract:
				return leftValue - rightValue;
			case Operators.Multiply:
				return leftValue * rightValue;
			case Operators.Divide:
				if (rightValue == 0)
					throw new DivideByZeroException ("Division by zero!");
				else
					return leftValue / rightValue;
			default:
				throw new NotImplementedException ("Invalid operator!");
			}
		}
	}
}
