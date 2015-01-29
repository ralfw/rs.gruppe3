using System;
using nback.contracts;

namespace nback.body
{
	class Timer {
		System.Threading.Timer timer;
		int _dSec;

		public Timer(int dSec) {
			this._dSec = dSec;
		}

		public void Start() {
			this.timer = new System.Threading.Timer (_ => Timeout (), null, this._dSec * 1000, System.Threading.Timeout.Infinite);
			Started ();
		}

		public void Stop() {
			this.timer.Change (System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
		}


		public int dSec { get { return this._dSec; } }

		public event Action Started;
		public event Action Timeout;
	}
}