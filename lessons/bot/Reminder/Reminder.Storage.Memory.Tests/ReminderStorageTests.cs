using NUnit.Framework;
using Reminder.Storage.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Storage.Memory.Tests
{
    class ReminderStorageTests
    {
        [Test]      // проверка метода добавления, получения, удаления
        public void GivenReminder_WhenAdd_ReturnById()
        {
            // 1. создаем объект хранилища со своим функционалом
            var storage = new ReminderStorage();
            // 2. создаем напоминалку
            var item = new ReminderItem("Some", "Contact", DateTimeOffset.UtcNow);
            // 3. Добавляем в словарь-хранилище
            storage.Add(item);
            // 4. Получаем из словаря-хранилища то, что добавили
            var found = storage.Get(item.Id);
            // 5. Суть проверки добавления и получения - сравниваем исходное добавленное и полученное из слова напоминалки
            Assert.AreEqual(item, found);
            // 6. Удаляем объект напоминалки, созданной выше
            var resultDelete = storage.Delete(item.Id);
            // 7. Суть проверки удаления
            Assert.AreEqual(resultDelete, true);
        }

        [Test]      // проверка выкидывания исключения
        public void GivenReminderWithSameId_WhenAdd_ThroowException()
        {
            // 1. создаем объект хранилища со своим функционалом
            var storage = new ReminderStorage();
            // 2. создаем напоминалку
            var item = new ReminderItem("Some", "Contact", DateTimeOffset.UtcNow);
            // 3. Добавляем в словарь-хранилище
            storage.Add(item);
            // 4. Суть теста - должно вылететь нужное исключение при работе нужной лямбды (делегата)
            Assert.Catch<ReminderItemAlreadyExistsException>(() => storage.Add(item));
        }

    }
}
