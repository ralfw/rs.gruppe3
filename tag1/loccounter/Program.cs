using System;
using System.IO;
using System.Linq;

// ein kommentar
namespace loccounter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// noch ein kommentar
			var filenames = Directory.GetFiles (args[0], "*.cs", SearchOption.AllDirectories);

			var totalLOC = 0;
			foreach (var fn in filenames) {
				var lines = File.ReadAllLines (fn);
				lines = lines.Where (l => !l.StartsWith ("//")).ToArray();
				lines = lines.Where (l => l.Trim () != "").ToArray ();
				totalLOC += lines.Length;
			}

			Console.WriteLine (totalLOC);
		}
	}
}
