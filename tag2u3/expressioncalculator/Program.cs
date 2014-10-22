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
			var comp = new Compiler ();
			var exp = new Evaluator ();

			cmd.Read_expression (
				source => comp.Compile(source,
					ast => exp.Eval(ast,
						con.Display_result,
						con.Display_error),
					con.Display_error),
				con.Display_error);
		}
	}


	class Compiler {
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
			var tokenstream = new List<Token> (tokens);
			var node = Recognize_expression (tokenstream);
			if (tokenstream.Count == 0)
				onSuccess (new AST{ Root = node });
			else
				onError ("Unexpected end of expression!");
		}

		private Node Recognize_expression(List<Token> tokenstream) {
			var node = Recognize_value (tokenstream);

			while (tokenstream.Count > 0 && (tokenstream.First () as OperatorToken) != null) {
				var op = Recognize_operator (tokenstream);
				var rightOperand = Recognize_value (tokenstream);

				op.Left = node;
				op.Right = rightOperand;
				node = op;
			}

			return node;
		}

		private Node Recognize_value(List<Token> tokenstream) {
			var operand = tokenstream.FirstOrDefault () as OperandToken;
			if (operand != null) {
				tokenstream.RemoveAt (0);
				return new OperandNode{ Value = operand.Value };
			}
			else
				throw new InvalidOperationException ("Missing value!");
		}

		private Node Recognize_operator(List<Token> tokenstream) {
			var op = tokenstream.FirstOrDefault () as OperatorToken;
			if (op != null) {
				tokenstream.RemoveAt (0);
				return new OperatorNode{ Op = op.Op };
			}
			else
				throw new InvalidOperationException ("Missing operator!");
		}
	}
}
