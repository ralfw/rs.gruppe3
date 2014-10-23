using System;
using shellforms.controls;
using System.Collections.Generic;

namespace spellchecker
{
	class Interactions {
		Spellchecker spell;
		DictionaryRepo dictRepo;

		public Interactions(Spellchecker spell, DictionaryRepo dictRepo) {
			this.dictRepo = dictRepo;
			this.spell = spell;
		}

		public string[] Prüfen(string text) {
			var worte = this.spell.In_Worte_zerlegen (text);
			var dict = dictRepo.Laden ();
			return this.spell.Worte_prüfen (dict, worte);
		}
	}


	class DictionaryRepo {
		public Dictionary Laden() {
			return new Dictionary ();
		}
	}
}
