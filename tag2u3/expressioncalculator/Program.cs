using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var cmd = new CommandlinePortal ();
			var con = new ConsolePortal ();
			var comp = new ExpressionCompiler ();
			var exp = new ExpressionEvaluator ();

			cmd.Read_expression (
				source => comp.Compile(source,
					ast => exp.Eval(ast,
						con.Display_result,
						con.Display_error),
					con.Display_error),
				con.Display_error);
		}
	}

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
		


	class ExpressionCompiler {
		public void Compile(string source, Action<AST> onSuccess, Action<string> onError) {
			Tokenize (source,
				tokens => Parse (tokens,
					onSuccess,
					onError),
				onError);
		}


		private void Tokenize(string source, Action<Token[]> onSuccess, Action<string> onError) {
			onSuccess (new Token[]{ 
				new OperandToken{Value=2},
				new OperatorToken{Op=Operators.Add},
				new OperandToken{Value=3},
				new OperatorToken{Op=Operators.Multiply},
				new OperandToken{Value=4},
			});
		}

		private void Parse(Token[] tokens, Action<AST> onSuccess, Action<string> onError) {
			var root = new OperatorNode{
				Op = Operators.Multiply,
				Left = new OperatorNode{
					Op = Operators.Add,
					Left = new OperandNode{Value=2},
					Right = new OperandNode{Value=3}
				},
				Right = new OperandNode{Value=4}
			};
			onSuccess (new AST{Root = root});
		}
	}
		


	public enum Operators {
		Add,
		Substract,
		Multiply,
		Divide
	}

	class Token {}

	class OperandToken : Token {
		public int Value;
	}

	class OperatorToken : Token {
		public Operators Op;
	}


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
