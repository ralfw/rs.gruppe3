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

			this.referee = new Referee ();
			this.timer = new Timer ();
			this.symgen = new SymbolGenerator ();
		}


		#region IBody implementation
		public event Action<GameState> Next_symbol_generated;
		public event Action<GameReport> Game_over;


		public void Start_game (string name, int n, int l, int dSec)
		{
			throw new NotImplementedException ();
		}

		public void Register_answer (Answers answer)
		{
			throw new NotImplementedException ();
		}

		public void Stop_game ()
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

