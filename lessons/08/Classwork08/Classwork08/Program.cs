using System;
using System.Collections.Generic;

namespace Classwork08
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.
            //    var doubleCollection = new List<double>();
            //    Console.WriteLine("Введите вещественные числа: ");
            //    Console.WriteLine("Среднее: " + methodSum(doubleCollection)/ (double)doubleCollection.Count);
            //}

            //static double methodSum(List<double> coll)
            //{
            //    for (double s = 0; ;)
            //    {
            //        var temp = Console.ReadLine();
            //        if (string.Equals(temp, "stop")) return s;
            //        coll.Add(double.Parse(temp));
            //        s += double.Parse(temp);
            //    }

            //2. недоделал!
            //var dict = new Dictionary<string, string>();
            //dict.Add("russia", "moscow");
            //dict.Add("armenia", "erevan");
            //dict.Add("france", "paris");

            //var rand = new Random();

            //while(true)
            //{
            //    var rNext = rand.Next(0, dict.Count);
            //    string strana = "moscow";
            //    Console.WriteLine($"Столица {strana}");
            //    string gorod = Console.ReadLine();
            //    if (!string.Equals(dict[strana], gorod))
            //        Console.WriteLine("Неверно!");
            //    else
            //    {
            //        Console.WriteLine("Верно!");
            //        break;
            //    }
            //}

            // 3.
            //var que = new Queue<double>();

            //while (true)
            //{
            //    string cr = Console.ReadLine();

            //    // случай с exit
            //    if (string.Equals(cr, "exit", StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine($"Число оставшихся {que.Count}");
            //        break;
            //    }
            //    // случай с run
            //    else if (string.Equals(cr, "run", StringComparison.OrdinalIgnoreCase))
            //    {
            //        queMethod(que);
            //    }
            //    // просто добавление
            //    else
            //        que.Enqueue(double.Parse(cr));
            //}

            //4.
            var st = new Stack<int>();
            bool run = true;
            while (run)
            {
                string cr = Console.ReadLine();

                switch (cr)
                {
                    case "wash":
                        st.Push(1);
                        Console.WriteLine($"Количество тарелок в стопке {st.Count}");
                        break;
                    case "dry":
                        if (st.Count == 0)
                        {
                            Console.WriteLine("Тарелок в стопке нет");
                            run = false;
                        }
                        else if (st.Count > 0) st.Pop();
                        Console.WriteLine($"Количество тарелок в стопке {st.Count}");
                        break;
                    case "exit":
                        Console.WriteLine($"Количество тарелок в стопке {st.Count}");
                        run = false;
                        break;
                }
                
            }



        }

        static void queMethod(Queue<double> que)
        {
            while (que.Count > 0)
            {
                var temp = que.Dequeue();
                Console.WriteLine($"{temp}^2 = {Math.Pow(temp, 2)}");

            }
        }
    }
}
