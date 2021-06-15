using System;

/// <summary>
/// Пространство имён, для собственных исключения
/// </summary>
namespace Reminder.Storage.Exceptions
{
    /// <summary>
    /// Класс исключений о том, что напоминалка с таким id не найдена
    /// </summary>
    public class ReminderItemNotFoundException : Exception
    {
        /// <summary>
        /// Создает исключение о том, что напоминалка с таким id не найдена
        /// </summary>
        /// <param name="id">передаваемый id напоминалки</param>
        public ReminderItemNotFoundException(Guid id) :
            base($"Reminder item with id {id} not found")      // через базовый конструктор передаем текст исключения
        {

        }
    }
}
