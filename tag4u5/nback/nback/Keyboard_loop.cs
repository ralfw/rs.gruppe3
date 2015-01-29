using System;
using nback.body;
using nback.contracts;

namespace nback
{

	class Keyboard_loop {
		bool keepWaiting;

		public void Wait_for_key(Action<char> onKey){
			this.keepWaiting = true;
			while (this.keepWaiting) {
				if (Console.KeyAvailable) {
					onKey (Console.ReadKey ().KeyChar);
				}
				System.Threading.Thread.Sleep (50);
			}
		}

		public void Abort() {
			this.keepWaiting = false;
		}
	}
}
