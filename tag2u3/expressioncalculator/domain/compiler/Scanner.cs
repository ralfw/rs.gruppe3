using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class Scanner {
		public void Tokenize(string source, Action<Token[]> onSuccess, Action<string> onError) {
			var tokens = new List<Token> ();
			var tokentext = "";
			var i = -1;

			while (++i < source.Length) {
				var c = source [i];
				if (char.IsDigit (c))
					tokentext += c;
				else { 
					if (tokentext != "") {
						tokens.Add (new OperandToken{ Value = int.Parse (tokentext) });
						tokentext = "";
					}
					switch (source [i]) {
					case '+':
						tokens.Add (new OperatorToken{ Op = Operators.Add });
						break;
					case '-':
						tokens.Add (new OperatorToken{ Op = Operators.Substract });
						break;
					case 'x':
					case '*':
						tokens.Add (new OperatorToken{ Op = Operators.Multiply });
						break;
					case '/':
						tokens.Add (new OperatorToken{ Op = Operators.Divide });
						break;
					default:
						if (!char.IsWhiteSpace (c)) {
							onError (string.Format("Invalid character: '{0}'", c));
							return;
						}
						break;
					}
				}
			}

			if (tokentext != "")
				tokens.Add (new OperandToken{ Value = int.Parse (tokentext) });

			onSuccess (tokens.ToArray ());
		}
	}
}
