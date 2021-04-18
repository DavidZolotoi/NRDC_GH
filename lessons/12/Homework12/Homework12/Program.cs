using System;

namespace Homework12
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(string phoneNumber, DateTimeOffset alarmDate, string alarmMessage = "Будильник") : base(alarmDate, alarmMessage)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException($"Что-то не так с номером телефона.");
            }
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties()    // метод вывода на экран всего
        {
            Console.WriteLine
            (
                $"AlarmDate: {AlarmDate},\n" +
                $"AlarmMessage: {AlarmMessage},\n" +
                $"TimeToAlarm: {TimeToAlarm},\n" +
                $"IsOutdated: {IsOutdated},\n" + 
                $"PhoneNumber: {PhoneNumber}."
            );
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var riPhone = new PhoneReminderItem("+79065557788", DateTimeOffset.Now.AddMinutes(30), "Выключи плиту");
            riPhone.WriteProperties();
        }
    }
}
