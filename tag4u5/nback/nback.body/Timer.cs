using System;
using nback.contracts;

namespace nback.body
{
	class Timer {
		int _dSec;

		public Timer(int dSec) {
			this._dSec = dSec;
		}

		public void Start() {
			Started ();
		}

		public void Stop() {

		}


		public int dSec { get { return this._dSec; } }

		public event Action Started;
		public event Action Timeout;
	}
}