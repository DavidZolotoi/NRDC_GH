/// <summary>
/// Проект=пространство имен, в котором:
/// - класс ReminderItem, описывающий все данные напоминалки (Id, Message, DateTime, Status...)
/// - перечисление ReminderItemStatus со всеми статусами
/// </summary>
namespace Reminder.Storage
{
    /// <summary>
    /// Тип перечисления статусов напоминалки
    /// </summary>
    public enum ReminderItemStatus
    {
        Created = 1,
        Ready,
        Failed,
        Successful
    }
}
