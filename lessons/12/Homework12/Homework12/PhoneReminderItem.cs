using System;

namespace Homework12
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }
        public string InfoPhoneReminderItem { get; private set; }                           // другая инфа о будильнике

        public PhoneReminderItem(string phoneNumber, DateTimeOffset alarmDate, string alarmMessage = "Будильник") : base(alarmDate, alarmMessage)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException($"Что-то не так с номером телефона.");
            }
            PhoneNumber = phoneNumber;
            InfoPhoneReminderItem = $"PhoneNumber:\t{PhoneNumber}.";
        }

        public override void WriteProperties()    // метод вывода на экран всего
        {
            Console.WriteLine(base.InfoTotal + InfoPhoneReminderItem);
        }
    }
}
