using System;
using nback.contracts;
using System.Collections.Generic;

namespace nback.body
{
	class Referee
	{
		private GameReport report;
		private List<char> symbols;
		private List<Answers> answers;
		private int l;


		public void Start_game(string name, int l) {
			this.report = new GameReport ();
			this.report.Name = name;
			this.report.StartedAt = DateTime.Now;

			this.symbols = new List<char> ();
			this.answers = new List<Answers> ();
		}

		public void Register_symbol(char symbol) {
			this.symbols.Add (symbol);
		}

		public void Register_answer(Answers answer) {
			this.answers.Add (answer);
		}

		public void Check_game_over(Action game_over) {
			if (this.answers.Count == this.l)
				game_over ();
		}

		public GameReport Generate_report() {
			this.report.Symbols = this.symbols.ToArray ();
			this.report.PercentRecognized = 42;
			this.report.PercentNotRecognized = 58;
			return this.report;
		}
	}
}