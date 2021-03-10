using System;

namespace L02_C07_var_long_ulong
{
	class Program
	{
		static void Main()
		{
			// Восьмибайтовое целое число
			// System.Int64 или ключевое слово long(-9 223 372 036 854 775 808 – 9 223 372 036 854 775 807)
			long yearOfBirth2 = 1982;
			Console.WriteLine(yearOfBirth2);

			// System.UInt64 или ключевое слово ulong(0 to 18 446 744 073 709 551 615)
			ulong nextToMaxLong = 9223372036854775807;
			Console.WriteLine(nextToMaxLong);
		}
	}
}
