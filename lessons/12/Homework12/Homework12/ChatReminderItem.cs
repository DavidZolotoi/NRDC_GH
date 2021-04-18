using System;

namespace Homework12
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }
        public override string InfoTotal =>                 // инфа о будильнике
            base.InfoTotal +
            $"ChatName:\t{ChatName},\n" +
            $"AccountName:\t{AccountName}.\n";


        public ChatReminderItem(string chatName, string accountName, DateTimeOffset alarmDate, string alarmMessage) : base(alarmDate, alarmMessage)
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
        }
    }
}
