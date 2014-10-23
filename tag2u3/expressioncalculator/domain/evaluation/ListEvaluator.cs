using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{

	class ListEvaluator : IEvaluator {
		public void Eval(AST expression, Action<int> onResult, Action<string> onError) {
			Errorhandling.Try (
				() => {
					var lists = Flatten(expression);
					var result = Eval (lists);
					onResult (result);
				},
				onError);
		}

		int Eval (Tuple<Operators[], int[]> lists) {
			var valueStack = Stack_operands (lists.Item2);
			return Apply_operators (lists.Item1, valueStack);
		}
			
		Stack<int> Stack_operands(int[] values) {
			return new Stack<int> (values.Reverse ());
		}
			
		int Apply_operators(Operators[] ops, Stack<int> operands) {
			foreach (var op in ops) {
				var left = operands.Pop ();
				var right = operands.Pop ();
				var result = Execute (op, left, right);
				operands.Push (result);
			}
			return operands.Pop ();
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

		Tuple<Operators[], int[]> Flatten(AST expression) {
			var ops = new List<Operators> ();
			var values = new List<int> ();
			Flatten (ops, values, expression.Root);
			return new Tuple<Operators[], int[]> (ops.ToArray (), values.ToArray ());
		}

		void Flatten(List<Operators> ops, List<int> values, Node node) {
			var operand = (node as OperandNode);
			if (operand != null) {
				values.Add (operand.Value);
				return;
			}

			var op = (node as OperatorNode);
			Flatten (ops, values, op.Left);
			Flatten (ops, values, op.Right);
			ops.Add (op.Op);
		}
	}
}
