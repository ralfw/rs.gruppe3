using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class Errorhandling {
		public static void Try(Action execute, Action<string> onError) {
			try {
				execute();
			}
			catch(Exception ex) {
				onError (ex.Message);
			}
		}
	}
}
