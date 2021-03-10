using System;

namespace L02_C05_var_short_ushort
{
	class Program
	{
		static void Main()
		{
			// Двухбайтовое целое число
			// System.Int16 или ключевое слово short(-32 768 – 32 767)
			short pressure = -21200;
			Console.WriteLine(pressure);

			// System.UInt16 или ключевое слово ushort(0 – 65 535)
			ushort yearOfBirth = 1982;
			Console.WriteLine(yearOfBirth);
		}
	}
}
