using System;
using System.Collections.Generic;

namespace Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            var ReminderItemList = new List<ReminderItem>(3)
            {
                new ReminderItem(DateTimeOffset.Now.AddMinutes(30), "Прошло полчаса"),
                new PhoneReminderItem("+79065557788", DateTimeOffset.Now.AddMinutes(55), "Отправить письмо на +79065557788"),
                new ChatReminderItem("Курс C#", "Змей Горыныч", DateTimeOffset.Now.AddMinutes(-30), "Пол часа назад написал")
            };

            foreach (var item in ReminderItemList)
            {
                item.WriteProperties();
            }

        }
    }
}
