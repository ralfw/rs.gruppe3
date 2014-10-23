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
			var comp = new Compiler (
							new Scanner(),
							new Parser()
						);
			IEvaluator exp = new ListEvaluator ();


			cmd.Read_expression (
				source => comp.Compile(source,
					ast => exp.Eval(ast,
						con.Display_result,
						con.Display_error),
					con.Display_error),
				con.Display_error);
		}
	}
}
