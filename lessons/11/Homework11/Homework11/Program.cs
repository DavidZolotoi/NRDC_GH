using System;

namespace Homework11
{

    class Program
    {
        static void Main(string[] args)
        {
            var people = new Person[3];

            // Ввод
            for (int i = 0; i < 3; i++)
            {
                people[i] = new Person()
                {
                    Name = ReadString("имя " + (i + 1)),
                    Age = ReadInt("возвраст " + (i + 1))
                };
            }

            //Вывод
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(people[i].Info);
            }

            Console.ReadKey();
        }

        // Метод для ввода текста с проверкой на пустоту с обработкой искл. и возвратом текста
        static string ReadString(string name)
        {
            string textCR; bool pustoi;
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}: ");
                    textCR = Console.ReadLine();

                    // ПРОВЕРКА на пустоты
                    pustoi = string.IsNullOrWhiteSpace(textCR);
                    if (pustoi)
                    {
                        WriteWithColor("Введенный текст пустой.", ConsoleColor.Red);
                        continue;
                    }

                    // ПРОВЕРКА на наличие букв
                    bool bukva = false;
                    foreach (var s in textCR)
                    {
                        // Проверка на наличие букв
                        if (char.IsLetter(s)) bukva |= true;        // bukva = char.IsLetter(s) ? bukva |= true : bukva;
                    }
                    if (!bukva)
                    {
                        WriteWithColor("Введенный текст не имеет букв алфавита.", ConsoleColor.Red);
                        continue;
                    }

                    return textCR;
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // Метод для ввода значения int с проверкой значений и адекватности возраста
        static int ReadInt(string name)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}: ");
                    int age = int.Parse(Console.ReadLine());

                    // Проверка на адекватность возраста
                    if (age < 0 || age > 130)
                    {
                        WriteWithColor("Введен неверный возраст", ConsoleColor.Red);
                        continue;
                    }

                    return age;
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
                                   //"Пожалуйста введите значение в пределах от " + int.MinValue + " до " + int.MaxValue + ".\n" +
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
