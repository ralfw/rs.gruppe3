using System;
using nback.body;
using nback.contracts;

namespace nback
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IBody body = new Body ();
			var head = new Head (body);

			head.Run (args);
		}
	}
}
