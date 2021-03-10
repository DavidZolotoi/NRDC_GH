using System;

namespace L02_C12_var_bool
{
	class Program
	{
		static void Main()
		{
			bool b = true;
			Console.WriteLine(b);   // True

			// Boolean operation AND
			// Boolean operation AND
			Console.WriteLine(true && true);   // logical AND: T && T = T
			Console.WriteLine(true && false);  // logical AND: T && F = F
			Console.WriteLine(false && false); // logical AND: F && F = F

			// Boolean operation OR
			Console.WriteLine(true || true);   // logical OR: T || T = T
			Console.WriteLine(true || false);  // logical OR: T || F = T
			Console.WriteLine(false || false); // logical OR: F || F = F
		}
	}
}
