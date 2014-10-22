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
			if (operand != null)
				return operand.Value;
			else {
				var leftValue = Eval (node.Left);
				var rightValue = Eval (node.Right);
				switch ((node as OperatorNode).Op) {
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
}
