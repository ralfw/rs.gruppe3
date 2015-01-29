using System;
using nback.body;
using nback.contracts;

namespace nback
{

	public class Head {
		IBody body;
		Keyboard_loop kbl;

		public Head(IBody body) {
			this.body = body;
			this.body.Next_symbol_generated += Show_next_symbol;
			this.body.Game_over += Show_report;

			this.kbl = new Keyboard_loop ();
		}

		public void Run(string[] args) {
			this.body.Start_game (args [0], int.Parse (args [1]), int.Parse (args [2]), int.Parse (args [3]));
		}

		private void Show_next_symbol(GameState gs) {
			this.kbl.Abort ();

			Console.Write ("\n{0}: {1} - [Space, x] ", gs.i, gs.Symbol);

			this.kbl.Wait_for_key (
				c => {
					switch(c) {
					case ' ':
						this.body.Register_answer(Answers.Recognized);
						break;
					case 'x':
						this.body.Stop_game();
						break;
					}
				}
			);
		}

		private void Show_report(GameReport report) {
			Console.WriteLine ("\n\nResult: {0}/{1}, started @ {2} by {3}", report.PercentRecognized, report.PercentNotRecognized, 
																            report.StartedAt, report.Name);
		}
	}
}