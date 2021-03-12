using System;

namespace Homework03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество людей: ");
            int kolvoImen = int.Parse(Console.ReadLine());
            Console.Write("Сколько лет добавить? ");
            int delta = int.Parse(Console.ReadLine());

            var imya = new string [kolvoImen];
            var vozrast1 = new int[kolvoImen];
            var vozrast2 = new int[kolvoImen];

            for (int i = 0; i < kolvoImen; i++)
            {
                Console.Write($"\nИмя {i+1}-о человека: ");
                imya[i]=Console.ReadLine();
                Console.Write($"Его возраст: ");
                vozrast1[i] = int.Parse(Console.ReadLine());

                vozrast2[i] = vozrast1[i] + delta;
            }

            for (int i=0; i<kolvoImen; i++)
            {
                Console.Write($"\n{i+1}. Имя: {imya[i]}, возраст через {delta} лет (год, года): {vozrast2[i]}");
            }


        }
    }
}
