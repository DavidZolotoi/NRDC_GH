using System;
using System.Threading;

namespace Reminder.Domain
{
    using Reminder.Sender;
    using ReminderReciver;
    using Storage;

	// Для каждого ReminderItem создать отдельный таймер с указанными в ReminderItem промежутком 
	// И в назначенный момент отправить сообщение
	// 19.40
	//   напомнить о конце занятия через 2 часа
	//   ReminderItem (конце занятия, 21.40)
	// Если ждать в основном потоке время необходимое для отправки сообщения,
	// то другие напоминлки обработать не сможем
	// Использовать подход:
	// Создать один таймер и раз в Н проверять существующие напоминалки
	// Если они есть - отправить их
	// Если нет - ничего не делать

	// 19.41
	// 19.42
	// ...
	// 21.40.00
	// 21.41.00

	// 
	// item
	//  dateTime: 21.40.20, status: created, contactId: P
	// item
	//  dateTime: 21.40.50, status: created, contactId: V
	// item
	//  dt: 22.50, s: sent
	// item
	//  dt: 09.00, s: created

	

	public class ReminderScheduler:IDisposable;
	{
		private Timer _createdTimer;
		private Timer _readyTimer;
		private readonly TimeSpan _timerPeriod;
		private readonly TimeSpan _timerDelay;
		private readonly IReminderStorage _storage;
		private readonly IReminderSender _sender;
		private readonly IReminderResiver _reciver;

		public ReminderScheduler(
			TimeSpan timerPeriod, 
			TimeSpan timerDelay, 
			IReminderStorage storage,
			IReminderSender sender,
			IReminderResiver reciver)
		{
			_timerPeriod = timerPeriod;
			_timerDelay = timerDelay;
			_storage = storage;
			_sender = sender;
			_reciver = reciver;
		}

		public void Start()
		{
			_reciver.MessageReceived += OnMessageReceived;
			_createdTimer = new Timer(OnCreatedTimerTick, null, _timerDelay, _timerPeriod);
			_readyTimer = new Timer(OnReadyTimerTick, null, _timerDelay, _timerPeriod);
		}

        private void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            
        }

        private void OnCreatedTimerTick(object _)
		{
			var datetime = DateTimeOffset.UtcNow;
			var items = _storage.Find(datetime, ReminderItemStatus.Created);

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
				try
				{
					_sender.Send(new ReminderNotification(item.Message, item.ContactId));
					item.MarkSuccessful();
				}
				// todo: eliminate generic Exception type
				catch (ReminderNotificationException)
				{
					item.MarkFailed();
				}

				_storage.Update(item);
			}
		}

        public void Dispose()
        {
			_createdTimer?.Dispose();
			_readyTimer?.Dispose();
			_reciver?.Dispose();
        }
    }
}