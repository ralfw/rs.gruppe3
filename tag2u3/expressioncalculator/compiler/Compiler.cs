using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class Compiler {
		Scanner scanner;
		Parser parser;

		public Compiler(Scanner scanner, Parser parser) {
			this.parser = parser;
			this.scanner = scanner;
		}

		public void Compile(string source, Action<AST> onSuccess, Action<string> onError) {
			scanner.Tokenize (source,
				tokens => parser.Parse (tokens,
					onSuccess,
					onError),
				onError);
		}
	}
}
