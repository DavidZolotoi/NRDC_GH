using System;

namespace Homework12
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }
        public override string InfoTotal =>                 // инфа о будильнике
            base.InfoTotal +
            $"PhoneNumber:\t{PhoneNumber}.\n";

        public PhoneReminderItem(string phoneNumber, DateTimeOffset alarmDate, string alarmMessage) : base(alarmDate, alarmMessage)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException($"Что-то не так с номером телефона.");
            }
            PhoneNumber = phoneNumber;
        }
    }
}
