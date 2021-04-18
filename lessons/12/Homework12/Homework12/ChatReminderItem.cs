using System;

namespace Homework12
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }

        public string InfoChatReminderItem { get; private set; }                           // другая инфа о будильнике

        public ChatReminderItem(string chatName, string accountName, DateTimeOffset alarmDate, string alarmMessage = "Будильник") : base(alarmDate, alarmMessage)
        {
            if (string.IsNullOrWhiteSpace(chatName))
            {
                throw new ArgumentException($"Что-то не так с названием чата.");
            }

            if (string.IsNullOrWhiteSpace(accountName))
            {
                throw new ArgumentException($"Что-то не так с именем аккаунта.");
            }

            ChatName = chatName;
            AccountName = accountName;
            InfoChatReminderItem =
                $"ChatName:\t{ChatName},\n" +
                $"AccountName:\t{AccountName}.";
        }

        public override void WriteProperties()    // метод вывода на экран всего
        {
            Console.WriteLine(base.InfoTotal + InfoChatReminderItem);
        }
    }
}
