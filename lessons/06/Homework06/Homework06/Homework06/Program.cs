using System;

namespace Homework06
{
    class Program
    {
        static void Main(string[] args)
        {

            int ost, quantitySimbol=0, quantityEven=0,
                positiveInteger = ReadInt("положительное натуральное число не более " + int.MaxValue + ": "),
                value = positiveInteger;
            while (value > 0)
            {
                quantitySimbol++;                                           // расчет количества цифр в числе
                ost = value % 10;                                           // нахождение самой последней цифры в числе
                quantityEven = (ost%2==0)? quantityEven+1: quantityEven;    // расчет количества четных цифр в числе
                value = value / 10;                                         // обрезка числа справа на 1 цифру
            }

            Console.WriteLine(
                               "Количество введенных цифр: " + quantitySimbol + "\n" +
                               "Количество четных цифр: " + quantityEven
                             );
        }

        // Метод для ввода значения int с проверкой значений
        static int ReadInt(string name)
        {
            int intMoreThanZero = -1;
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    intMoreThanZero = int.Parse(Console.ReadLine());
                    if (intMoreThanZero<=0)
                    {
                        WriteWithColor("Введенное значение не положительное. Попробуйте ещё раз.", ConsoleColor.Red);
                        continue;
                    }
                    return intMoreThanZero;
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)     //int.Parse()
                {
                    WriteWithColor("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
                }
                catch (OverflowException exception)             //int.Parse()
                {
                    WriteWithColor("Введенное значение выходит за пределы допустимых.\n" +
                                   "Пожалуйста введите значение до " + int.MinValue +" " + int.MaxValue + ".\n" +
                                   exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentException exception)              //int.Parse()
                {
                    WriteWithColor("Что-то пошло не так, возможно не удаётся распознать способ округления.\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // Метод вывода сообщения в цвете
        static void WriteWithColor(string message, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = restoreColor;
        }


    }
}
