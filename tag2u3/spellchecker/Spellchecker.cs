using System;
using shellforms.controls;
using System.Collections.Generic;
using System.Linq;

namespace spellchecker
{
	class Spellchecker {
		public string[] In_Worte_zerlegen(string text) {
			return text.Split (new[]{ ' ', '.', ',', '!', ';', ':', '?', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public string[] Worte_prüfen(Dictionary dict, string[] worte) {
			return worte.Where(w => !Is_an_acronym(w))
						.Select (w => w.ToLower ())
				        .Where (w => !dict.Contains (w))
				        .Distinct ()
				        .ToArray ();
		}

		private bool Is_an_acronym(string word) {
			return string.Compare (word, word.ToUpper (), false) == 0;
		}
	}
}
