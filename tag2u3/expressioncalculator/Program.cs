using System;
using System.Linq;

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
			onError ("no eval yet!");
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
				new OperatorToken{Op=OperatorToken.Operators.Add},
				new OperandToken{Value=3},
				new OperatorToken{Op=OperatorToken.Operators.Multiply},
				new OperandToken{Value=4},
			});
		}

		private void Parse(Token[] tokens, Action<AST> onSuccess, Action<string> onError) {
			onError ("no parsing yet");
		}
	}
		


	class Token {}

	class OperandToken : Token {
		public int Value;
	}

	class OperatorToken : Token {
		public enum Operators {
			Add,
			Substract,
			Multiply,
			Divide
		}
		public Operators Op;
	}


	class AST {}
}
