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
			onError("no tokenization yet");
		}

		private void Parse(Token[] tokens, Action<AST> onSuccess, Action<string> onError) {
			onError ("no parsing yet");
		}
	}
		
	class CommandlinePortal {
		public void Read_expression(Action<string> onExpression, Action<string> onError) {
			if (Environment.GetCommandLineArgs ().Length > 1)
				onExpression (string.Join (" ", Environment.GetCommandLineArgs ().Skip (1)));
			else
				onError ("Usage example: expressioncalculator 2 + 3 x 4 / 5");
		}
	}


	class Token {}

	class AST {}
}
