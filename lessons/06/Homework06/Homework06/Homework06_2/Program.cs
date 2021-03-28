using System;

namespace Homework06_2
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sumStart = ReadDecimal("сумму первоначального взноса в рублях (максимум 2 знака после запятой): ", 2),
                    sum = sumStart,
                    percent = ReadDecimal("ежедневный процент дохода в виде десятичной дроби (1% = 0.01, максимум 4 знака после запятой): ", 4),
                    sumTarget = ReadDecimal("желаемую сумму накопления в рублях: ", 2);
            int numberOfDays;
            bool isError = false;       // индикатор ошибки выхода расчетов за пределы decimal

            for(numberOfDays=1; sum<=sumTarget; numberOfDays++)
            {
                try
                {
                    sum = Math.Round(sum + sum * percent, 2, MidpointRounding.ToEven);
                    //Console.WriteLine($"\nday: {numberOfDays}");
                    //Console.WriteLine($"sum: {sum}");
                }
                catch (OverflowException exception)
                {
                    WriteWithColor("Расчетное значение вышло за пределы допустимых.\n" +
                                   "Программа может считать числа в пределах от " + decimal.MinValue + " до " + decimal.MaxValue + ".\n" +
                                   exception.Message, ConsoleColor.Red);
                    isError = true;
                    break;
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    WriteWithColor("Количество знаков после запятой выходит за пределы допутимого.\n" +
                                   exception.Message, ConsoleColor.Red);
                    isError = true;
                    break;
                }
            }
            if (isError == false)
                Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы: {numberOfDays-1}");
            else
                Console.WriteLine("Не удалось корректно посчитать ответ.");
        }

        // Метод для ввода значения decimal с указанием кол-ва знаков после запятой и проверкой значений
        static decimal ReadDecimal(string name, int accuracy)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    var value1 = decimal.Parse(Console.ReadLine());
                    var value2 = Math.Round(value1, accuracy, MidpointRounding.ToEven);
                    if (value1<0)
                    {
                        WriteWithColor("Введенное значение меньше нуля. Пожалуйста введите значение больше нуля.", ConsoleColor.Red);
                        continue;
                    }
                    if (value1 - value2 > 0)
                    {
                        WriteWithColor("Предупреждение! Введенное значение имеет больше знаков после запятой, чем " + accuracy +
                                       "\nДля расчетов будет использоваться округленное до " + accuracy + " знаков после запятой значение = " + value2, ConsoleColor.Magenta);
                    }
                    if (value2 == 0)
                    {
                        WriteWithColor("Введенное значение, округленное до " + accuracy + " знаков после запятой равно нулю.\n" +
                                       "Пожалуйста, введите значение отличное от нуля.", ConsoleColor.Red);
                        continue;
                    }
                    return value2;
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)     //decimal.Parse()
                {
                    WriteWithColor("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
                }
                catch (OverflowException exception)             //decimal.Parse()
                {
                    WriteWithColor("Введенное значение выходит за пределы допустимых.\n" +
                                   "Пожалуйста, введите значение в пределах от " + decimal.MinValue + " до " + decimal.MaxValue + ".\n" +
                                   exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine(), Math.Round()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentException exception)              //Math.Round()
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