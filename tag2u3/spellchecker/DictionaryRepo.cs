using System;
using shellforms.controls;
using System.Collections.Generic;
using System.IO;

namespace spellchecker
{
	class DictionaryRepo {
		public Dictionary Laden() {
			var words = File.ReadAllLines ("Deutsch.txt");
			return new Dictionary (words);
		}
	}
}
