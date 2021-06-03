using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.Memory
{
    using Exceptions;

    public class ReminderStorage : IReminderStorage
    {
        private readonly Dictionary<Guid, ReminderItem> _items;
        public ReminderStorage()
        {
            _items = new Dictionary<Guid, ReminderItem>();
        }

        public void Add(ReminderItem item)
        {
            var result = _items.TryAdd(item.Id, item);
            if (!result)
            {
                // Duplicate
                throw new ReminderAlreadyExistsException(item.Id);
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ReminderItem[] Find(DateTimeOffset? dateTime, ReminderItemStatus status)
        {

            var items = _items.Values.AsEnumerable();

            if (dateTime.HasValue)
            { items = items.Where(item => item.DateTime <= dateTime.Value); }

            return items
                .Where(item => item.Status == status)
                .OrderBy(item => item.DateTime)
                .ToArray();
        }

        public ReminderItem Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
