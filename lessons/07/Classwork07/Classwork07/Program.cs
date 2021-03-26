using System;
using System.Text;

namespace Classwork07
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            Console.WriteLine("Введите два числа");
            double t1 = double.Parse(Console.ReadLine());
            double t2 = double.Parse(Console.ReadLine());

            Console.WriteLine(t1.ToString("F2") +"*"+t2.ToString("F2") +"="+(t1*t2).ToString("F2"));
            Console.WriteLine(string.Format("{0:F2}+{1:F2}={2:F2}", t1,t2,t1+t2));
            Console.WriteLine($"{t1:.##}-{t2:.##}={(t1-t2):.##}") ;

            //2.
            string text = "   lorem   ipsum   dolor   sit   amet   ";
            string[] text2 = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            text2[1] = text2[1].ToUpper();

            var text3 = string.Join(' ', text2);
            Console.WriteLine(text3);

            string text4 = text3.Substring(text3.Length-text3.LastIndexOf(' '));
            Console.WriteLine(text4);

            StringBuilder sb = new StringBuilder(text);
            for (int i = 0; i < sb.Length; i++)
            {
                //if (sb[i] == "" || sb[i] == " ") { }
            }

            //foreach (string s in text2)
            //{
            //    //text3 = string.Join(' ', s);
            //    Console.WriteLine(s);
            //}




        }
    }
}
