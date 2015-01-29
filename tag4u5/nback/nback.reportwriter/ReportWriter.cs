using System;
using nback.contracts;

namespace nback.reportwriter
{
	public class ReportWriter : IReportWriter
	{
		#region IReportWriter implementation
		public void Write (GameReport report)
		{
			Console.WriteLine ("### ReportWriter.Write()");
		}
		#endregion
	}
}

