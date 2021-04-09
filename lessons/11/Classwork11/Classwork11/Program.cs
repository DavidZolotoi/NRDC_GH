using System;

namespace Classwork11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Pet2 p2 = new Pet2("Bobik", 'M', new DateTime(2019, 04, 8), "Dog")
            {
                Name = "Bobik2",
                Sex = 'M',
                DateOfBirth = new DateTime(2019, 04, 8),
                Kind = "Dog2"
            };
            p2.WriteInfo(true);

            Console.ReadKey();  // ожидание нажатия
        }
    }
}
