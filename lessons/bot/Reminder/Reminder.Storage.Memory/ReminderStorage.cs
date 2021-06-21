using System;
using System.Collections.Generic;

/// <summary>
/// Проект=пространство имён, в котором реализуется работа с памятью.
/// Содержит класс, реализующий интерфейс работы с напоминалками в памяти, содержащий словарь.
/// </summary>
namespace Reminder.Storage.Memory
{
    using Exceptions;       // для использования ReminderItemAlreadyExistsException в методе Add
    /// <summary>
    /// Класс, реализующий IReminderStorage для работы с напоминалками в памяти, содержащий словарь.
    /// </summary>
    public class ReminderStorage : IReminderStorage
    {
        /// <summary>
        /// Свойство=Словарь для хранения/обновления напоминалок в формате (id, напоминалка)
        /// </summary>
        private readonly Dictionary<Guid, ReminderItem> _items;

        /// <summary>
        /// Создает объект класса, реализующий IReminderStorage для работы с напоминалками в памяти, содержащий словарь.
        /// В конструкторе создается словарь (id, напоминалка) и помещается в поле.
        /// </summary>
        public ReminderStorage()
        {
            _items = new Dictionary<Guid, ReminderItem>();
        }

        /// <summary>
        /// Метод добавления напоминалок в память=словарь. Часть реализации интерфейса.
        /// Результат либо true либо исключение ReminderItemAlreadyExistsException
        /// </summary>
        /// <param name="item">передаваемый объект напоминалки</param>
        public void Add(ReminderItem item)
        {
            var result =_items.TryAdd(item.Id, item);
            if (!result)
            {
                throw new ReminderItemAlreadyExistsException(item.Id);
            }
        }

        /// <summary>
        /// Метод удаления напоминалок из памяти=словаря. Часть реализации интерфейса.
        /// Результат либо true либо исключение ReminderItemNotFoundException
        /// </summary>
        /// <param name="id">передаваемый id напоминалки</param>
        public bool Delete(Guid id)
        {
            var result = _items.Remove(id);
            if (!result) throw new ReminderItemNotFoundException(id);
            return result;
        }

        /// <summary>
        /// Метод получения напоминалок из памяти=словаря. Часть реализации интерфейса.
        /// Результат либо напоминалка либо исключение ReminderItemNotFoundException
        /// </summary>
        /// <param name="id">передаваемый id напоминалки</param>
        /// <returns></returns>
        public ReminderItem Get(Guid id)
        {
            var result = _items.TryGetValue(id, out ReminderItem item);
            if (result) return item;
            else throw new ReminderItemNotFoundException(id);
        }

        /// <summary>
        /// Метод обновления напоминалки в памяти=словаре. Часть реализации интерфейса.
        /// Уведомления об успехе - нет. Если что-то пойдет не так, то исключения (ReminderItemNotFoundException/ReminderItemAlreadyExistsException)
        /// </summary>
        /// <param name="item">передаваемая напоминалка</param>
        public void Update(ReminderItem item)
        {
            // удаляем старую версию напоминалки, если такого Id нет, то выдаст исключение ReminderItemNotFoundException
            Delete(item.Id);
            // добавляем обновленную, если будут проблемы с добавлением, то выдаст исключение ReminderItemAlreadyExistsException
            Add(item);
        }
    }
}
