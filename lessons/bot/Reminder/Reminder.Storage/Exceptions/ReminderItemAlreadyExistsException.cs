using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пространство имён, для собственных исключения
/// </summary>
namespace Reminder.Storage.Exceptions
{
    /// <summary>
    /// Класс исключений о том, что напоминалка с таким id уже существует
    /// </summary>
    public class ReminderItemAlreadyExistsException : Exception
    {
        /// <summary>
        /// Создаёт исключение о том, что напоминалка с таким id уже существует
        /// </summary>
        /// <param name="id">передаваемый id напоминалки</param>
        public ReminderItemAlreadyExistsException(Guid id) :
            base($"Reminder item with id {id} already exists")      // через базовый конструктор передаем текст исключения
        {

        }
    }
}
