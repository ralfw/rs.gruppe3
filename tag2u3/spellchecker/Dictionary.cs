using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{

	class Dictionary {
		private HashSet<string> dict;

		public Dictionary(IEnumerable<string> words) {
			this.dict = new HashSet<string> (words);
		}

		public bool Contains(string word) {
			return this.dict.Contains (word);
		}
	}
}
