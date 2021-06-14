using System;
/// <summary>
/// Проект=пространство имен, в котором:
/// - класс ReminderItem, описывающий все данные напоминалки (Id, Message, DateTime, Status...)
/// - перечисление ReminderItemStatus со всеми статусами
/// </summary>
namespace Reminder.Storage
{
    /// <summary>
    /// Интерфейс, описывающий хранение данных (добавление, обновление, удаление, получение)
    /// </summary>
    public interface IReminderStorage
    {
        /// <summary>
        /// Метод, объявленный в интерфейсе IReminderStorage, отвечающий за добавление данных
        /// </summary>
        /// <param name="item">передаваемый объект напоминалки</param>
        void Add(ReminderItem item);
        /// <summary>
        /// Метод, объявленный в интерфейсе IReminderStorage, отвечающий за обновление данных
        /// </summary>
        /// <param name="item">передаваемый объект напоминалки</param>
        void Update(Guid id);
        /// <summary>
        /// Метод, объявленный в интерфейсе IReminderStorage, отвечающий за удаление данных
        /// </summary>
        /// <param name="item">передаваемый объект напоминалки</param>
        void Delete(Guid id);
        /// <summary>
        /// Метод, объявленный в интерфейсе IReminderStorage, отвечающий за получение данных
        /// </summary>
        /// <param name="item">передаваемый объект напоминалки</param>
        ReminderItem Get(Guid id);
    }
}
