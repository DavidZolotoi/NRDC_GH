using System;

namespace classwork16
{
    public sealed class Circle
    {
        private double _radius;
        public Circle (double radius)
        {
            _radius = radius;
        }
        public double Calculate(Func<double, double> operation)
        {
            return operation(_radius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(2);
            var d = c.Calculate((r) => 2*r);
            var s = c.Calculate((r) => Math.PI*r*r);
            var l = c.Calculate((r) => 2*Math.PI*r);
        }
    }
}
