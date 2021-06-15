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
        /// Метод добавления напоминалок в память=словарь. Часть реализации интерфейса
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


        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод получения напоминалок из памяти=словаря. Часть реализации интерфейса
        /// </summary>
        /// <param name="id">передаваемый id напоминалки</param>
        /// <returns></returns>
        public ReminderItem Get(Guid id)
        {
            var result = _items.TryGetValue(id, out ReminderItem item);
            if (result) return item;
            else throw new ReminderItemNotFoundException(id);
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
