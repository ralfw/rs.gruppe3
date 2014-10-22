using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{

	class ExpressionEvaluator{
		public void Eval(AST expression, Action<int> onResult, Action<string> onError) {
			Try (
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
						throw new DivideByZeroException ();
					else
						return leftValue / rightValue;
				default:
					throw new NotImplementedException ("Invalid operator!");
				}
			}
		}
			
		private void Try(Action execute, Action<string> onError) {
			try {
				execute();
			}
			catch(Exception ex) {
				onError ("Evaluation failed with: " + ex.GetType().Name);
			}
		}
	}

}
