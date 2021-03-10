using System;

namespace L02_C08_var_float
{
	class Program
	{
		static void Main()
		{
			// Четырехбайтовое дробное число (точность ~6-9 знаков после запятой)
			// System.Single или ключевое слово float(±1.5×10 ^−45 – ±3.4×10 ^ 38)

			float a = 3.5F;
			Console.WriteLine(a);

			int x = 3;
			float y = 4.5f;
			short z = 5;
			var result = x * y / z;
			Console.WriteLine("The result is {0}", result);
			Type type = result.GetType();
			Console.WriteLine("result is of type {0}", type.ToString());
		}
	}
}
