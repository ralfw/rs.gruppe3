using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class Evaluator{
		public void Eval(AST expression, Action<int> onResult, Action<string> onError) {
			Errorhandling.Try (
				() => {
					var result = Eval (expression.Root);
					onResult (result);
				},
				onError);
		}
			
		private int Eval(Node node) {
			var operand = node as OperandNode;
			if (operand != null) return operand.Value;

			var leftValue = Eval (node.Left);
			var rightValue = Eval (node.Right);
			return Execute ((node as OperatorNode).Op, leftValue, rightValue);
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
