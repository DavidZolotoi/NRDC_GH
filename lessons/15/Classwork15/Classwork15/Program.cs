using System;

namespace Classwork15
{
    // 1.
    class Account<T>
    {
        public T Id { get; private set; }

        public string Name { get; private set; }

        public Account(T id, string name)
        {
            if (!(string.IsNullOrEmpty(name) && (id != null)))
            {
                Id = id;
                Name = name;
            }
            else throw new ArgumentException("беда с аргументами");
        }

        public void WriteProperties()
        {
            Console.WriteLine($"Id={Id}, Name={Name}");
        }

    }

    // 2.
    public sealed class Circle
    {
        private double _radius;
    
        public Circle(double radius)
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
            // 1.
            var ac1 = new Account<int>(1, "Вася");
            var ac2 = new Account<string>("2", "Петя");
            var ac3 = new Account<Guid>(Guid.NewGuid(), "Гриша");

            ac1.WriteProperties();
            ac2.WriteProperties();
            ac3.WriteProperties();

            // 2. 
            var c = new Circle(1.5);
            Console.WriteLine($"S = {c.Calculate(operS)}");
            Console.WriteLine($"L = {c.Calculate(operL)}");
        }
        // метод с сигнатурой делегата для расчета площади
        static double operS(double radiuc)
        {
            return Math.PI * radiuc * radiuc;
        }
        // метод с сигнатурой делегата для расчета длины
        static double operL(double radiuc)
        {
            return Math.PI * 2 * radiuc;
        }
    }
}
