using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{

	class Dictionary {
		private HashSet<string> dict;

		public Dictionary() {
			this.dict = new HashSet<string>(){ "hund", "katze", "maus" };
		}

		public bool Contains(string word) {
			return this.dict.Contains (word);
		}
	}
}
