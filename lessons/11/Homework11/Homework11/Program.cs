using System;

namespace Homework11
{
    class ReminderItem
    {
        // Свойства
        public DateTimeOffset AlarmDate { get; set; }   // ДАТА БУДИЛЬНИКА
        public string AlarmMessage { get; set; }        // Сообщение будильника
        public TimeSpan TimeToAlarm => DateTimeOffset.UtcNow - AlarmDate;           // разница от настоящего времени
        public bool IsOutdated => (TimeToAlarm.TotalSeconds >= 0);                  // прошел?

        // Методы
        public ReminderItem()
        {
            try
            {
                AlarmDate = new DateTimeOffset           // запись даты будильника
                    (
                    ReadInt("год"),
                    ReadInt("месяц"),
                    ReadInt("день"),
                    ReadInt("час"),
                    ReadInt("минуты"),
                    ReadInt("секунды"),
                    TimeSpan.FromHours(+3)
                    );
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine("Не удаётся распознать дату. \n" + exception.Message);
                Environment.Exit(0);
            }

            AlarmMessage = ReadString("наименование");          // запись сообщения будильника
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

        // Метод для ввода строки со всеми проверками
        public string ReadString(string name)
        {
            string text;
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}: ");
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

        // Метод для ввода значения int с проверкой значений
        public int ReadInt(string name)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}: ");
                    int intValue = int.Parse(Console.ReadLine());

                    return intValue;
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    Console.WriteLine("Слишком большое количество символов\n" + exception.Message);
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)     //int.Parse()
                {
                    Console.WriteLine("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message);
                }
                catch (OverflowException exception)             //int.Parse()
                {
                    Console.WriteLine("Введенное значение выходит за пределы допустимых.\n" +
                                   //"Пожалуйста введите значение в пределах от " + int.MinValue + " до " + int.MaxValue + ".\n" +
                                   exception.Message);
                }
                catch (ArgumentException exception)              //int.Parse()
                {
                    Console.WriteLine("Что-то пошло не так, возможно не удаётся распознать способ округления.\n" + exception.Message);
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           ReminderItem ri1 = new ReminderItem();
            ri1.WriteProperties();

            ReminderItem ri2 = new ReminderItem();
            ri2.WriteProperties();
        }
    }
}
