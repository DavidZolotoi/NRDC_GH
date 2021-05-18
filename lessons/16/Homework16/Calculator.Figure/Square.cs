using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Figure
{
	public sealed class Square
	{
		private readonly double _side;

		public Square(double side)
		{
			_side = side;
		}

		public double Calculate(Func<double, double> operation)
		{
			return operation(_side);
		}
	}
}
