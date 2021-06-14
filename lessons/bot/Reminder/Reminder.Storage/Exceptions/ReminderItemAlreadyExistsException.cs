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
    /// Исключение о том, что напоминалка с таким id уже существует
    /// </summary>
    public class ReminderItemAlreadyExistsException : Exception
    {
        public ReminderItemAlreadyExistsException(Guid id) :
            base($"Reminder item with id {id} already exists")      // через базовый конструктор передаем текст исключения
        {

        }
    }
}
