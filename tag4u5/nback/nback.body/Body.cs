using System;
using nback.contracts;

namespace nback.body
{
	public class Body : IBody
	{
		IReportWriter reporter;
		Referee referee;
		Timer timer;
		SymbolGenerator symgen;

		public Body(IReportWriter reporter) {
			this.reporter = reporter;
		}
			

		#region IBody implementation
		public event Action<GameState> Next_symbol_generated;
		public event Action<GameReport> Game_over;


		public void Start_game (string name, int n, int l, int dSec)
		{
			this.symgen = new SymbolGenerator (n, l);
			this.referee = new Referee (name, n, l);

			this.timer = new Timer (dSec);
			this.timer.Started += Publish_symbol;
			this.timer.Timeout += () => Process_answer (Answers.NotRecognized);

			Advance_symbol ();
		}

		public void Register_answer (Answers answer)
		{
			this.timer.Stop ();
			Process_answer (answer);
		}

		public void Stop_game ()
		{
			this.timer.Stop ();
			Finish_game ();
		}
		#endregion
	

		private void Advance_symbol() {
			var symbol = this.symgen.Generate ();
			this.referee.Register_symbol (symbol);
			this.timer.Start ();
		}

		private void Publish_symbol() {
			var gs = new GameState{ 
				Symbol = this.referee.Current_symbol,
				i = this.referee.Current_symbol_index,
				dSec = timer.dSec
			};
			this.Next_symbol_generated (gs);
		}

		private void Process_answer(Answers answer) {
			this.referee.Register_answer (answer);
			this.referee.Check_game_over (
				Advance_symbol,
				Finish_game
			);
		}
			
		private void Finish_game() {
			var report = this.referee.Generate_report();
			this.reporter.Write(report);
			this.Game_over(report);
		}
	}
}