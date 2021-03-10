using System;

namespace L02_C09_var_double
{
	class Program
	{
		static void Main()
		{
			// Восьмибайтовое дробное число(точность ~15 - 17 знаков после запятой)
			// System.Double или ключевое слово double(±5.0×10 ^−324 – ±1.7×10 ^ 308)

			double a = 3D;
			Console.WriteLine(a);

			// Output: 3

			// Mixing types in expressions
			int x = 3;
			float y = 4.5f;
			short z = 5;
			double w = 1.7E+3;
		
			// Result of the 2nd argument is a double:
			Console.WriteLine("The sum is {0}", x + y + z + w);

			// Output: The sum is 1712.5
		}
	}
}
