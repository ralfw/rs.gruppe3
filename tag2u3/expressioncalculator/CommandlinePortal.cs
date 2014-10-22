using System;
using System.Linq;

namespace expressioncalculator
{
		
	class CommandlinePortal {
		public void Read_expression(Action<string> onExpression, Action<string> onError) {
			if (Environment.GetCommandLineArgs ().Length > 1)
				onExpression (string.Join (" ", Environment.GetCommandLineArgs ().Skip (1)));
			else
				onError ("Usage example: expressioncalculator 2 + 3 x 4 / 5");
		}
	}
	
}
