using System;
using nback.body;
using nback.contracts;

namespace nback
{

	public class Head {
		IBody body;

		public Head(IBody body) {
			this.body = body;

			this.body.Next_symbol_generated += Show_next_symbol;
			this.body.Game_over += Show_report;
		}

		public void Run(string[] args) {
			this.body.Start_game (args [0], int.Parse (args [1]), int.Parse (args [2]), int.Parse (args [3]));
		}

		private void Show_next_symbol(GameState gs) {
			Console.WriteLine ("{0}: {1}", gs.i, gs.Symbol);
		}

		private void Show_report(GameReport report) {
			Console.WriteLine ("{0}/{1}, started @ {2} by {3}", report.PercentRecognized, report.PercentNotRecognized, 
																report.StartedAt, report.Name);
		}
	}
}
