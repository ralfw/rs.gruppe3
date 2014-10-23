using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{
	class Spellchecker {
		public string[] Prüfen(string text) {
			var worte = In_Worte_zerlegen (text);
			return Worte_prüfen (worte);
		}


		string[] In_Worte_zerlegen(string text) {
			return text.Split (new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
		}


		string[] Worte_prüfen(string[] worte) {
			var wörterbuch = new HashSet<string>(){ "hund", "katze", "maus" };
			var fehler = new List<string> ();
			foreach (var w in worte) {
				if (!wörterbuch.Contains(w.ToLower()))
					fehler.Add(w);
			}
			return fehler.ToArray ();
		}
	}
}
