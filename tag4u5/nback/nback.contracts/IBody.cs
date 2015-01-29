using System;

namespace nback.contracts
{
	public interface IBody
	{
		void Start_game (string name, int n, int l, int dSec);
		void Register_answer(Answers answer);
		void Stop_game();

		event Action<GameState> Next_symbol_generated;
		event Action<GameReport> Game_over;
	}
}