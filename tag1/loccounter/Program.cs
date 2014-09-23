using System;
using System.IO;

namespace loccounter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var filenames = Directory.GetFiles (args[0], "*.cs", SearchOption.AllDirectories);

			var totalLOC = 0;
			foreach (var fn in filenames) {
				var lines = File.ReadAllLines (fn);
				totalLOC += lines.Length;
			}

			Console.WriteLine (totalLOC);
		}
	}
}
