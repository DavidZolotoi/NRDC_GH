using System;

namespace Homework11
{
    class ReminderItem
    {
        // Свойства
        public DateTimeOffset AlarmDate { get; set; }   // ДАТА БУДИЛЬНИКА
        public string AlarmMessage { get; set; }        // Сообщение будильника
        public TimeSpan TimeToAlarm => DateTimeOffset.UtcNow - AlarmDate;           // разница от настоящего времени
        public bool IsOutdated => (TimeToAlarm.TotalSeconds >= 0) ? true : false;   // прошел?

        // Методы
        public ReminderItem(int year, int month, int day, int hour, int minute, int second, TimeSpan offset, string message)        // конструктор
        {
            AlarmDate = new DateTimeOffset(year, month, day, hour, minute, second, offset);                         // запись даты будильника
            AlarmMessage = message;                                                                                 // запись сообщения будильника
        }

        public void WriteProperties()    //выводить на экран все
        {
            Console.WriteLine
                (
                $"AlarmDate: {AlarmDate},\nAlarmMessage: {AlarmMessage},\nTimeToAlarm: {TimeToAlarm},\nIsOutdated: {IsOutdated}"
                );
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            ReminderItem ri1 = new ReminderItem(2021, 4, 13,
                                                6, 00, 00,
                                                TimeSpan.FromHours(+3),
                                                "Пора просыпаться");
            ReminderItem ri2 = new ReminderItem(2021, 4, 15,
                                                6, 00, 00,
                                                TimeSpan.FromHours(+3),
                                                "Пора просыпаться");
            ri1.WriteProperties();
            ri2.WriteProperties();
        }
    }
}
