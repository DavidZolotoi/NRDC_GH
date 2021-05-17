using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
	public static class SquareOperations
    {
		public static double Perimeter(double side)
		{
			return 4 * side;
		}

		public static double Square(double side)
		{
			return Math.Pow(side, 2);
		}
	}

}
