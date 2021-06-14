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
        /// <param name="item"></param>
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

        // пока так
        public ReminderItem Get(Guid id)
        {
            var result = _items.TryGetValue(id, out ReminderItem item);
            if (result) return item;
            // Надо сделать собственное исключение
            else throw new Exception($"Не удалось найти id={id} в хранилище");
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
