using System;

namespace L02_C04_var_byte_sbyte
{
	class Program
	{
		static void Main()
		{
			// Однобайтовое целое число
			// System.Byte или ключевое слово byte(0 – 255)
			byte age = 36;
			Console.WriteLine(age);
			byte ageInHex = 0x24;
			Console.WriteLine(ageInHex);

			// System.SByte или ключевое слово sbyte(-128 – 127)
			sbyte min = -128;
			Console.WriteLine(min);
		}
	}
}
