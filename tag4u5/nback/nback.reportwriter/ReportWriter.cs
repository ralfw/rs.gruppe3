using System;
using nback.contracts;
using System.IO;

namespace nback.reportwriter
{
	public class ReportWriter : IReportWriter
	{
		string reportfilepath;

		public ReportWriter(string reportfilepath) {
			this.reportfilepath = reportfilepath;
		}

		#region IReportWriter implementation
		public void Write (GameReport report)
		{
			var reporttext = string.Format ("{0}\n{1}\n{2} / {3}\n{4}", 
												report.Name, report.StartedAt, 
												report.PercentRecognized, report.PercentNotRecognized, 
												report.Symbols.ToString());
			File.AppendAllText (this.reportfilepath, reporttext);
		}
		#endregion
	}
}

