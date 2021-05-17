using System;

namespace Calculator.Operation
{
	public static class CircleOperations
	{
		public static double Perimeter(double radius)
		{
			return 2 * Math.PI * radius;
		}

		public static double Square(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}
