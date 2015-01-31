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
			IReportWriter reporter = new ReportWriter ("report.txt");
			var symgenFactory = new Func<int,int, SymbolGenerator>((int n, int l) => new SymbolGenerator (n, l));
			var refereeFactory = new Func<string,int,int,Referee>((string name, int n, int l) => new Referee (name, n, l));
			var timerFactory = new Func<int,Timer>((int dSec) => new Timer (dSec));

			IBody body = new Body (reporter, symgenFactory, refereeFactory, timerFactory);
			var head = new Head (body);

			head.Run (args);
		}
	}
}
