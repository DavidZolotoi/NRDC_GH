using System;

namespace L02_C06_var_int_uint
{
	class Program
	{
		static void Main()
		{
			// Четырехбайтовое целое число
			// System.Int32 или ключевое слово int(-2 147 483 648 – 2 147 483 647)
			int minutesInYear = 365 * 24 * 60;
			Console.WriteLine(minutesInYear);

			// System.UInt32 или ключевое слово uint(0 – 4 294 967 295)
			uint tempInCenterOfSun = 15000000;
			Console.WriteLine(tempInCenterOfSun);
		}
	}
}
