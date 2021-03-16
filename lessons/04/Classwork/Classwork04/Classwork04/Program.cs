using System;

namespace Classwork04
{
    class Program
    {
        static void Main(string[] args)
        {
            // пирамида
            Console.Write("Введите сторону основания а:");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите высоту h:");
            double h = double.Parse(Console.ReadLine());

            var H = Math.Round(Math.Sqrt(h * h - a * a / 12), 3, MidpointRounding.AwayFromZero);

            Console.WriteLine($"Высота пирамиды H = {H}");
            Console.WriteLine($"Боковая площ. Sб = {Math.Round(3*a*h, 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"Полная площадь Sп = {Math.Round((3.0/2)*a*(a*Math.Sqrt(3)+2*h), 3, MidpointRounding.AwayFromZero)}");
            Console.WriteLine($"Объем пирамиды V = {Math.Round(a*a*H*Math.Sqrt(3)/2, 3, MidpointRounding.AwayFromZero)}");



        }
    }
}
