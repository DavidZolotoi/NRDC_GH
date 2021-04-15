using System;

namespace Homework11
{
    class ReminderItem
    {
        // Свойства
        public DateTimeOffset AlarmDate { get; set; }                           // ДАТА БУДИЛЬНИКА
        public string AlarmMessage { get; set; }                                // Сообщение будильника
        public TimeSpan TimeToAlarm => DateTimeOffset.UtcNow - AlarmDate;       // разница от настоящего времени
        public bool IsOutdated => (TimeToAlarm.TotalSeconds >= 0);              // прошел?

        // Методы
        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;          // все проверки были в методе ввода с бесконечным циклом и ловлей исключений
            AlarmMessage = alarmMessage;    // все проверки были в методе ввода с бесконечным циклом и ловлей исключений 
        }

        public void WriteProperties()    // метод вывода на экран все
        {
            Console.WriteLine
                (
                $"AlarmDate: {AlarmDate},\n" +
                $"AlarmMessage: {AlarmMessage},\n" +
                $"TimeToAlarm: {TimeToAlarm},\n" +
                $"IsOutdated: {IsOutdated}"
                );
        }
}


    class Program
    {
        static void Main(string[] args)
        {
           ReminderItem ri1 = new ReminderItem
                (
                ReadDateTime("Введите дату (день/месяц/год), время (часы:минуты:секунды AM/PM) и разницу часовых поясов через пробел (знак ч:м): "),
                ReadTitle("Введите название будильника: ")
                );
            ri1.WriteProperties();

            ReminderItem ri2 = new ReminderItem
                (
                ReadDateTime("Введите дату (день/месяц/год), время (часы:минуты:секунды AM/PM) и разницу часовых поясов через пробел (знак ч:м): "),
                ReadTitle("Введите название будильника: ")
                );
            ri2.WriteProperties();
        }


        // Метод для ввода даты (день/месяц/год), времени (часы:минуты:секунды AM/PM) и разницы часовых поясов через пробел (± ч:м) со всеми проверками
        static DateTimeOffset ReadDateTime(string name)
        {
            string text;
            for (; ; )
            {
                try
                {
                    Console.WriteLine(name);
                    text = Console.ReadLine();
                    // проверка на пустоту
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("Вы ввели пустой текст. Пожалуйста, попробуйте еще раз.");
                        continue;
                    }
                    else
                    {
                        return DateTimeOffset.Parse(text);
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
        static string ReadTitle(string name)
        {
            string text;
            for (; ; )
            {
                try
                {
                    Console.Write($"{name}");
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
