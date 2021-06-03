using Reminder.Storage;
using System;
using System.Threading;

namespace Reminder.Domain
{
    public class ReminderSheduler
    {
        private Timer _createdTimer;
        private Timer _readyTimer;
        private TimeSpan _timerPeriod;
        private TimeSpan _timerDelay;
        private readonly IReminderStorage _storage;
        public ReminderSheduler(TimeSpan timerPeriod, TimeSpan timerDelay, IReminderStorage storage)
        {
            _timerPeriod = timerPeriod;
            _timerDelay = timerDelay;
            _storage = storage;
        }

        public void Start()
        {
            _createdTimer = new Timer(OnCreatedTimerTick, null, _timerPeriod, _timerDelay);
            _readyTimer = new Timer(OnReadyTimerTick, null, _timerPeriod, _timerDelay);
        }

        private void OnCreatedTimerTick(object _)
        {
            //найти все reminderItem
            var datetime = DateTimeOffset.UtcNow;
            var status = ReminderItemStatus.Created;

            var items = _storage.Find(datetime, status);

            foreach (var item in items)
            {
                item.MarkReady();
                _storage.Update(item);
            }
        }

        private void OnReadyTimerTick(object _)
        {
            var items = _storage.Find(null, ReminderItemStatus.Ready);

            foreach (var item in items)
            {
                // не дописал
            }
        }
    }
}
