using System;
using shellforms.controls;

namespace spellchecker
{
	class UI : Screen {
		Listbox lstFehler;
		Textbox tbPrüftext;

		public UI() {
			this.tbPrüftext = new Textbox (2, 2, 40);
			this.controls.Add (this.tbPrüftext);

			var btnPrüfen = new Button (2, 3, "Prüfen");
			btnPrüfen.OnPressed += BtnPrüfen_pressed;
			this.controls.Add (btnPrüfen);

			this.lstFehler = new Listbox (2, 5, 15, 10);
			this.controls.Add (this.lstFehler);
		}

		public void BtnPrüfen_pressed(Button sender) {
			this.Prüfgrundlage_verändert (this.tbPrüftext.Text);
		}

		public void Fehler_anzeigen(string[] fehler) {
			this.lstFehler.Items = fehler;
		}

		public event Action<string> Prüfgrundlage_verändert;
	}
}
