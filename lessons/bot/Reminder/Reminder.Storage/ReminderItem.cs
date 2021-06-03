using System;

namespace Reminder.Storage
{
    public class ReminderItem
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public string ContactId { get; private set; }
        public DateTimeOffset DateTime { get; private set; }
        public ReminderItemStatus Status { get; private set; }

        public ReminderItem(string message, string contactId, DateTimeOffset dateTime)
        {
            Id = Guid.NewGuid();
            Message = message;
            DateTime = dateTime;
            ContactId = contactId;
            Status = ReminderItemStatus.Created;
        }

        public void MarkReady() =>
             ChangeStatus(ReminderItemStatus.Ready, ReminderItemStatus.Ready);

        public void MarkRSuccessful() =>
             ChangeStatus(ReminderItemStatus.Ready, ReminderItemStatus.Successful);

        public void MarkFailed() =>
             ChangeStatus(ReminderItemStatus.Ready, ReminderItemStatus.Failed);

        private void ChangeStatus(ReminderItemStatus ready, ReminderItemStatus failed)
        {
            // не дописал
        }
    } 
    
    public interface IReminderStorage
        {
            void Add(ReminderItem item);
            void Update(ReminderItem item);
            void Delete(Guid id);
            ReminderItem Get(Guid id);
            ReminderItem[] Find(DateTimeOffset? dateTime, ReminderItemStatus status);
        }
}
