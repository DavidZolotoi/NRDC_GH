using System;

namespace L02_C13_comparing_operators
{
	class Program
	{
		static void Main()
		{
			// Result of comparison is a boolean type value
			bool a = 12 > 17;
			Console.WriteLine(a);	// Statement 12 > 17 is wrong, result is False

			bool b = "one" == "two"; // Strings are different, result is False
			Console.WriteLine(b);

			bool c = "one" != "two"; // Strings are different, result is True
			Console.WriteLine(c);

			bool d = 12 != 12;       // Numbers are the same, result is False
			Console.WriteLine(!d);   // We asked for NOT(d), result is True
		}
	}
}
