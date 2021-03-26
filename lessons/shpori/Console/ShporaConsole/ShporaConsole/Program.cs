using System;
using System.Threading;

namespace ShporaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 05. 

            // 04. Полезные методы при использовании Nullabla
            int? a; a = 5;
            Console.WriteLine(a.GetValueOrDefault());   // вернуть значение или default
            Console.WriteLine(a.HasValue);              // имеет ли значение?
            Console.WriteLine(a.Value);                 // само значение

            // 03. Способы сравнения строк
            Console.WriteLine("03");
            Console.WriteLine("ttt".Equals("tttgh"));
            Console.WriteLine(string.Equals("ttt", "tttgh")) ;

            // 02. Метод с таймером, аргумент количество мс в типе данных int [-2 147 483 648; 2 147 483 647]
            Console.WriteLine("02");
            Timer(1000);

            // 01. Метод вывода сообщения в цвете
            Console.WriteLine("01");
            WriteWithColor("Сообщение в зеленом цвете", ConsoleColor.Green);
        }



        // 02. Метод с таймером, аргумент количество мс в типе данных int [-2 147 483 648; 2 147 483 647]
        static void Timer(int msek)
        {
            try
            {
                Thread.Sleep(msek);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                WriteWithColor("Некорректное время для таймера, пожалуйста введите целое число от 0 до " + int.MaxValue + "\n" + ex.Message, ConsoleColor.Red);
            }
        }

        // 01. Метод вывода сообщения в цвете
        static void WriteWithColor(string message, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = restoreColor;
        }

    }
}
