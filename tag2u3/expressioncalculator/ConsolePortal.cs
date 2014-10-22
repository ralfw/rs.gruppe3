using System;
using System.Linq;

namespace expressioncalculator
{

	class ConsolePortal {
		public void Display_result(int result) {
			Console.BackgroundColor = ConsoleColor.Green;
			Console.Write (result);
			Console.ResetColor ();
		}

		public void Display_error(string errorMsg) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write (errorMsg);
			Console.ResetColor ();
		}
	}
	
}
