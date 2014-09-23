using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// ein kommentar
namespace loccounter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var quelle = Verzeichnis_bestimmen (args);
			var dateinamen = Dateien_sammeln (quelle);
			var dateien = Relevante_Dateien_erkennen (dateinamen);
			var zeilen = Relevante_Zeilen_extrahieren (dateien);
			var loc = Ergebnis_bestimmen (zeilen);
			Ergebnis_präsentieren (loc);
		}

		static string Verzeichnis_bestimmen (string[] args)
		{
			return args [0];
		}

		static string[] Dateien_sammeln (string quelle)
		{
			return Directory.GetFiles (quelle, "*.*", SearchOption.AllDirectories);
		}

		static IEnumerable<string[]>  Relevante_Dateien_erkennen (string[] dateinamen)
		{
			return dateinamen.Select (dn => File.ReadAllLines (dn));
		}

		static IEnumerable<string> Relevante_Zeilen_extrahieren (IEnumerable<string[]> dateien)
		{
			return dateien.SelectMany (d => d.Where (l => l.Trim () != "").Where (l => !l.Trim ().StartsWith ("//")));
		}

		static object Ergebnis_bestimmen (IEnumerable<string> zeilen)
		{
			return zeilen.Count ();
		}

		static void Ergebnis_präsentieren (object loc)
		{
			Console.Write (loc);
		}
	}
}
