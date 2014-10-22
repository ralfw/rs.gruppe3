using System;
using System.Collections.Generic;
using System.Linq;

namespace fromroman
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var roman = Read_roman ();
			var arabic = From_roman (roman);
			Write_result (arabic);
		}

		static string Read_roman ()
		{
			return Environment.GetCommandLineArgs () [1];
		}

		static int From_roman (string roman)
		{
			var runes = roman.ToCharArray ();
			var runeValues = Map_runes (runes);
			var signs = Determine_signs (runeValues);
			var signedValues = Apply_signs (runeValues, signs);
			return signedValues.Sum ();
		}

		static int[] Map_runes (char[] runes)
		{
			var map = new Dictionary<char,int> () { {'L', 50}, {'X', 10}, {'V', 5}, {'I', 1}};
			return runes.Select (r => map [r]).ToArray ();
		}

		static int[] Determine_signs (int[] runeValues)
		{
			var signs = Enumerable.Repeat (1, runeValues.Length).ToArray ();
			for (var i = 0; i < runeValues.Length - 1; i++)
				if (runeValues [i] < runeValues [i + 1])
					signs [i] = -1;
			return signs.ToArray ();
		}

		static int[] Apply_signs (int[] runeValues, int[] signs)
		{
			return runeValues.Select ((rv, i) => rv * signs [i]).ToArray ();
		}


		static void Write_result (int arabic)
		{
			Console.Write (arabic);
		}
	}
}
