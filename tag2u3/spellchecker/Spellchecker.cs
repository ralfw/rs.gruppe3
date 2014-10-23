using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{
	class Spellchecker {
		public string[] In_Worte_zerlegen(string text) {
			return text.Split (new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public string[] Worte_prüfen(Dictionary dict, string[] worte) {
			var fehler = new List<string> ();
			foreach (var w in worte) {
				if (!dict.Contains(w.ToLower()))
					fehler.Add(w);
			}
			return fehler.ToArray ();
		}
	}
}
