using System;
using shellforms.controls;
using System.Collections.Generic;
using System.Linq;

namespace spellchecker
{
	class Spellchecker {
		public string[] In_Worte_zerlegen(string text) {
			return text.Split (new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public string[] Worte_prüfen(Dictionary dict, string[] worte) {
			return worte.Select (w => w.ToLower ())
				        .Where (w => !dict.Contains (w))
				        .Distinct ()
				        .ToArray ();
		}
	}
}
