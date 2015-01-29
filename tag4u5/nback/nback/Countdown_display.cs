using System;
using nback.body;
using nback.contracts;

namespace nback
{
	class Countdown_display {
		System.Threading.Timer timer;

		public void Start(int dSec) {
			this.timer = new System.Threading.Timer (_ => {
				Console.Write(".");
			}, null, 0, 1000);
		}

		public void Stop() {
			if (this.timer == null) return;
			this.timer.Change (System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
		}
	}
}