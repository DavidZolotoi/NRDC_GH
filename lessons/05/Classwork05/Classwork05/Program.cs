using System;

namespace Classwork05
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            Console.WriteLine("Введите возраст человека:");

            for (int i = 1; i < 10; i++)
            {
                var age = byte.Parse(Console.ReadLine());
                var ost = age % 10;

                var god = ost == 1 && (age >= 12 || age == 1)
                    ? "год"
                    : (ost >= 2 && ost <= 4 && (age >= 15 || age < 10))
                        ? "года"
                        : "лет";

                Console.WriteLine($"Человеку {age} {god}.");

            }

            // Правильнее найти отдельно десятки и отдельно остатки

        }
    }
}
