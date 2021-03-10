using System;

namespace L02_C11_parse_method
{
	class Program
	{
		static void Main()
		{
			string s = "175";
			int i = int.Parse(s);
			Console.WriteLine(i + 25);

			Console.WriteLine(byte.Parse("7"));
			Console.WriteLine(sbyte.Parse("7"));
			Console.WriteLine(short.Parse("7"));
			Console.WriteLine(ushort.Parse("7"));

			Console.WriteLine(int.Parse("7"));
			Console.WriteLine(uint.Parse("7"));
			Console.WriteLine(long.Parse("7"));
			Console.WriteLine(ulong.Parse("7"));

			Console.WriteLine(float.Parse("7"));
			Console.WriteLine(double.Parse("7"));
			Console.WriteLine(decimal.Parse("7"));
		}
	}
}
