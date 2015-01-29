using System;
using nback.body;
using nback.contracts;
using nback.reportwriter;

namespace nback
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IReportWriter reporter = new ReportWriter ();
			IBody body = new Body (reporter);
			var head = new Head (body);

			head.Run (args);
		}
	}
}
