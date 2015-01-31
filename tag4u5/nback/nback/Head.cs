using System;
using nback.body;
using nback.contracts;
using CLAP;

namespace nback
{
	public class Head {
		IBody body;
		Keyboard_loop kbl;
		Countdown_display countdown;

		public Head(IBody body) {
			this.body = body;
			this.body.Next_symbol_generated += Show_next_symbol;
			this.body.Game_over += Show_report;

			this.kbl = new Keyboard_loop ();
			this.countdown = new Countdown_display ();
		}


		public void Run(string[] args) {
			Parser.Run (args, this);
		}


		[Verb(IsDefault=true)]
		public void StartGame(
			[Required]			string name,
			[DefaultValue(3)]	int n, 
			[Required]			int l, 
			[DefaultValue(3),
			 Aliases("d")]		int dSec) {
			this.body.Start_game (name, n, l, dSec);
		}


		private void Show_next_symbol(GameState gs) {
			this.kbl.Abort ();
			this.countdown.Stop ();

			Console.Write ("\n{0}: {1} - [Space, x] ", gs.i, gs.Symbol);

			this.countdown.Start (gs.dSec);
			this.kbl.Wait_for_key (c => {
				switch(c) {
				case ' ':
					this.body.Register_answer(Answers.Recognized);
					break;
				case 'x':
					this.body.Stop_game();
					break;
				}
			});
		}


		private void Show_report(GameReport report) {
			this.kbl.Abort ();
			this.countdown.Stop ();
			Console.WriteLine ("\n\nResult: {0}/{1}, started @ {2} by {3}", report.PercentRecognized, report.PercentNotRecognized, 
																            report.StartedAt, report.Name);
		}
	}
}