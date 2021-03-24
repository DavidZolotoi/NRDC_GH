using System;

namespace Classwork06
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            //string t;
            //do
            //{
            //    t = Console.ReadLine();
            //    if (t == "exit") break;
            //    if (t.Length <= 15)
            //        Console.WriteLine($"Entered string lenght is {t.Length}.");
            //    else
            //    {
            //        Console.WriteLine("Too long string. Try another:");
            //        continue;
            //    }
            //}
            //while (true);

            // 2.
            //var arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //int i = 0, s = 0;
            //while (i<arr.Length)
            //{
            //    s += arr[i++];
            //    Console.WriteLine($"После {i}-й итерации S = {s}");
            //}

            // 3.
            var marks = new[]
            {
                new [] { 2, 3, 3, 2, 3},
                new [] { 2, 4, 5, 3},
                null,
                new [] { 5, 5, 5, 5 },
                new [] {4}
            };

            double median;
            var s = 0;
            var k = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                double medianj = 0;
                var sj = 0;
                if (marks[i] == null)
                {
                    Console.WriteLine($"В {i+1}-й день оценок не было");
                    continue;
                }

                for (int j = 0; j < marks[i].Length; j++)
                {
                    sj += marks[i][j];
                }
                medianj = Math.Round((double)sj / marks[i].Length, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine($"Сумма за {i+1}-й день = {sj}");
                Console.WriteLine($"Среднее за {i+1}-й день = {medianj}");
                Console.WriteLine("");

                s += sj;
                k += marks[i].Length;
            }
            median = Math.Round((double)s / k, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"Сумма за неделю = {s}");
            Console.WriteLine($"Среднее за неделю = {median}");
        }
    }
}
