using System;

namespace nback.contracts
{
	public interface IReportWriter {
		void Write(GameReport report);
	}
}
