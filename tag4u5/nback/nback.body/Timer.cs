using System;
using nback.contracts;

namespace nback.body
{
	class Timer {
		public void Start(int dSec) {
			Started ();
		}

		public void Stop() {

		}

		public event Action Started;
		public event Action Timeout;
	}
}