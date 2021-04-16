using System;

namespace Homework11
{

    class Program
    {
        static void Main(string[] args)
        {

            var reminderItems = new ReminderItem[2];
            for (int i = 0; i < reminderItems.Length; i++)
            {
                reminderItems[i] = new ReminderItem
                    (
                    ReadDateTime(),
                    ReadTitle()
                    );
                reminderItems[i].WriteProperties();
            }

        }


        // Метод для ввода даты (день/месяц/год), времени (часы:минуты:секунды AM/PM) и разницы часовых поясов через пробел (± ч:м) со всеми проверками
        static DateTimeOffset ReadDateTime()
        {
            for (; ; )
            {
                try
                {
                    Console.WriteLine("Введите дату (день/месяц/год), время (часы:минуты:секунды AM/PM) и разницу часовых поясов через пробел (знак ч:м): ");
                    string readDateTimeString = Console.ReadLine();
                    // проверка на пустоту
                    if (string.IsNullOrWhiteSpace(readDateTimeString))
                    {
                        Console.WriteLine("Вы ввели пустой текст. Пожалуйста, попробуйте еще раз.");
                        continue;
                    }
                    else
                    {
                        return DateTimeOffset.Parse(readDateTimeString);
                    }
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    Console.WriteLine("Слишком большое количество символов.\n" + exception.Message);
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)   //DateTimeOffset.Parse()
                {
                    Console.WriteLine("Не удается распознать дату/время/смещение, вероятно запись неккоректна.\n" + exception.Message);
                }
                catch (ArgumentException exception)   //DateTimeOffset.Parse()
                {
                    Console.WriteLine("Не удается распознать дату/время/смещение, возможно указано недопустимое смещение.\n" + exception.Message);
                }
            }
        }

        // Метод для ввода строки со всеми проверками
        static string ReadTitle()
        {
            string text;
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите название будильника: ");
                    text = Console.ReadLine();

                    // проверка на пустоту
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Вы не ввели пустой текст. Пожалуйста, попробуйте еще раз.");
                        continue;
                    }

                    return text;
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    Console.WriteLine("Слишком большое количество символов\n" + exception.Message);
                }
            }
        }
    }
}
