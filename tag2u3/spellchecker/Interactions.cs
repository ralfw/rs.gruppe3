using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{
	class Interactions {
		Spellchecker spell;

		public Interactions(Spellchecker spell) {
			this.spell = spell;
		}

		public string[] Prüfen(string text) {
			var worte = this.spell.In_Worte_zerlegen (text);
			var dict = new Dictionary ();
			return this.spell.Worte_prüfen (dict, worte);
		}
	}
}
