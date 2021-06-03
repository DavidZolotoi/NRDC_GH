using System;

namespace Reminder.Sender
{
    [Serializable]
    public class ReminderNotificationException : Exception
    {
        public ReminderNotificationException(string message, Exception inner) : base(message, inner) { }
    }
}
