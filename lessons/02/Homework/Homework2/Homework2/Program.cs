using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            string deistvie;
            double chislo1, chislo2;

            Console.Write("Выберите действие (+, -, *, /, %, ^):");
            deistvie = Console.ReadLine();                  //стоить сделать проверку значения

            Console.Write("Введите первое число:");
            chislo1 = double.Parse(Console.ReadLine());     //стоить сделать проверку значения

            Console.Write("Введите второе число:");
            chislo2 = double.Parse(Console.ReadLine());     //стоить сделать проверку значения

            Console.Write(chislo1 + deistvie + chislo2 + "=");

            switch (deistvie)
            {
                case "+":
                    Console.WriteLine(chislo1 + chislo2);
                    break;
                case "-":
                    Console.WriteLine(chislo1 - chislo2);
                    break;
                case "*":
                    Console.WriteLine(chislo1 * chislo2);
                    break;
                case "/":
                    if (chislo2 == 0) Console.WriteLine("На ноль делить нельзя!"); else Console.WriteLine(chislo1 / chislo2);
                    break;
                case "%":
                    if (chislo2 == 0) Console.WriteLine("На ноль делить нельзя!"); else Console.WriteLine(chislo1 % chislo2);
                    break;
                case "^":
                    Console.WriteLine(Math.Pow(chislo1, chislo2));
                    break;
                default:
                    Console.WriteLine("Не удалось посчитать, вероятно введенные данные неверны.");
                    break;
            }

        }
    }
}
