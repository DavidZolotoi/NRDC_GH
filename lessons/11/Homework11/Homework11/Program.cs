using System;

namespace Homework11
{
    class ReminderItem
    {
        // Свойства
        public DateTimeOffset AlarmDate { get; set; }   // ДАТА БУДИЛЬНИКА
        public string AlarmMessage { get; set; }        // Сообщение будтльника
        public TimeSpan TimeToAlarm;    // => текущее время минус AlarmDate
        public bool IsOutdated;    //=> true, если TimeToAlarm больше либо равно 0

        // Методы
        public ReminderItem()       // конструктор
        {
            // значение AlarmDate
            AlarmDate = new DateTimeOffset(2021, 04, 13, 15, 30, 00, TimeToAlarm);      //?
            // AlarmMessage
            AlarmMessage = "Пора на работу";
        }
        public static void WriteProperties() { }    //выводить на экран все
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
