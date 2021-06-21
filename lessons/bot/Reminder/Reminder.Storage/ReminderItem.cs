using System;

/// <summary>
/// Проект=пространство имен, в котором:
/// - класс ReminderItem, описывающий все данные напоминалки (Id, Message, DateTime, Status...)
/// - перечисление ReminderItemStatus со всеми статусами
/// </summary>
namespace Reminder.Storage
{

    /// <summary>
    /// Класс, входящий в Reminder.Storage, описывающий все данные напоминалки (Id, Message, ContactId, DateTime, Status...)
    /// </summary>
    public class ReminderItem
    {
        /// <summary>
        /// Id напоминалки
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Текст напоминалки
        /// </summary>
        public string Message { get; private set; }     // открытый метод, имеющий доступ к редактированию MessageTryUpdate
        /// <summary>
        /// Открытый метод, для редактирования закрытого (для редакт.) свойства Message
        /// </summary>
        /// <param name="messageNew">передаваемый новый текст для редактирования</param>
        /// <returns></returns>
        public bool MessageTryUpdate(string messageNew)
        {
            if (string.IsNullOrEmpty(messageNew)) return false; // вместо false можно выкинуть своё исключение
            // здесь также можно добавить исключения типа старый и новый тексты одинаковые
            Message = messageNew;
            return true;
        }
        /// <summary>
        /// Отправитель/создатель напоминалки
        /// </summary>
        public string ContactId { get; private set; }
        /// <summary>
        /// Время напоминалки
        /// </summary>
        public DateTimeOffset DateTime { get; private set; }
        /// <summary>
        /// Статус напоминалки
        /// </summary>
        public ReminderItemStatus Status { get; private set; }

        /// <summary>
        /// Создание объекта напоминалки со всеми данными (Id, Message, ContactId, DateTime, Status...)
        /// </summary>
        /// <param name="message">передаваемый текст напоминалки</param>
        /// <param name="contactId">передаваемый отправитель/создатель напоминалки</param>
        /// <param name="dateTime">передаваемое время напоминалки</param>
        public ReminderItem(string message, string contactId, DateTimeOffset dateTime)
        {
            Id        = Guid.NewGuid();
            Message   = message;
            ContactId = contactId;
            DateTime  = dateTime;
            Status    = ReminderItemStatus.Created;
        }
    }
}
