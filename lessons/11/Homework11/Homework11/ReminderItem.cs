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

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage="Будильник")
        {
            AlarmDate = alarmDate;
            if (string.IsNullOrWhiteSpace(alarmMessage))
                Console.WriteLine($"Что-то не так с наименованием будильника. Будет записано значение по умолчанию: \"{alarmMessage}\"");
                AlarmMessage = alarmMessage;
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
}
