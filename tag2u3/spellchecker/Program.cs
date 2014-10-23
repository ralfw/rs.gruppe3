using System;
using shellforms.controls;

namespace spellchecker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var ui = new UI ();
			var sc = new Spellchecker ();

			ui.Prüfgrundlage_verändert += text => {
				var fehler = sc.Prüfen (text);
				ui.Fehler_anzeigen (fehler);
			};

			var sf = new shellforms.ShellForms ();
			sf.Run (ui);
		}
	}
}
