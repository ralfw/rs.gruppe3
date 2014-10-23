using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	interface IEvaluator {
		void Eval (AST expression, Action<int> onResult, Action<string> onError);
	}
	
}
