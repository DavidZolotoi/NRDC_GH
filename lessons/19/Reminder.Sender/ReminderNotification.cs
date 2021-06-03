namespace Reminder.Sender
{
    public class ReminderNotification
    {
        public string Message { get; }
        public string ContctId { get; }
        public ReminderNotification(string message, string contctId)
        {
            Message = message;
            ContctId = contctId;
        }
    }
}
