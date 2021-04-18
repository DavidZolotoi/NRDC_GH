using System;

namespace Homework12
{
    class ReminderItem
    {
        // Свойства
        public DateTimeOffset AlarmDate { get; set; }                           // ДАТА БУДИЛЬНИКА
        public string AlarmMessage { get; set; }                                // Сообщение будильника
        public TimeSpan TimeToAlarm => DateTimeOffset.UtcNow - AlarmDate;       // разница от настоящего времени
        public bool IsOutdated => (TimeToAlarm.TotalSeconds >= 0);              // прошел?
        public string InfoTotal { get; private set; }                           // общая инфа о будильнике

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;

            if (string.IsNullOrWhiteSpace(alarmMessage))
            {
                Console.WriteLine($"Что-то не так с наименованием будильника. Будет записано значение по умолчанию: \"{alarmMessage}\"");
                alarmMessage = "Будильник";
            }
            AlarmMessage = alarmMessage;

            InfoTotal =
                $"Type:\t{this.GetType()}\n" +
                $"AlarmDate:\t{AlarmDate},\n" +
                $"AlarmMessage:\t{AlarmMessage},\n" +
                $"TimeToAlarm:\t{TimeToAlarm},\n" +
                $"IsOutdated:\t{IsOutdated},\n";
        }

        public virtual void WriteProperties()    // метод вывода на экран всего
        {
            Console.WriteLine(InfoTotal);
        }
    }
}
