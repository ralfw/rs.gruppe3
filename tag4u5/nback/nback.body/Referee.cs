using System;
using System.Linq;
using nback.contracts;
using System.Collections.Generic;

namespace nback.body
{
	class Referee
	{
		private GameReport report;
		private List<char> symbols;
		private List<Answers> answers;
		private int n, l;

		public Referee(string name, int n, int l) {
			this.report = new GameReport ();
			this.report.Name = name;
			this.report.StartedAt = DateTime.Now;

			this.n = n;
			this.l = l;

			this.symbols = new List<char> ();
			this.answers = new List<Answers> ();
		}

		public void Register_symbol(char symbol) {
			this.symbols.Add (symbol);
		}

		public void Register_answer(Answers answer) {
			this.answers.Add (answer);
		}

		public void Check_game_over(Action game_continues, Action game_over) {
			if (this.answers.Count == this.l)
				game_over ();
			else
				game_continues ();
		}

		//TODO: Do real reporting by checking the answers against the symbols
		public GameReport Generate_report() {
			this.report.Symbols = this.symbols.ToArray ();

			this.report.PercentRecognized = (int)(this.answers.Count (a => a == Answers.Recognized) / (double)this.l * 100);
			this.report.PercentNotRecognized = 100 - this.report.PercentRecognized;
			return this.report;
		}


		public char Current_symbol { get { return this.symbols.Last (); } }
		public int Current_symbol_index { get { return this.symbols.Count; } }
	}
}