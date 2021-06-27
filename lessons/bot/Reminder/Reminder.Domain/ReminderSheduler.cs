using System;
using System.Threading;

/// <summary>
/// Проект, содержащий логику работы бота (домен)
/// </summary>
namespace Reminder.Domain
{
    // добавляем Storage, чтоб увидеть IReminderStorage
    using Storage;

    /// <summary>
    /// Класс, объекты которого будут выполнять логику бота (имеет таймер)
    /// </summary>
    public class ReminderSheduler
    {

        private Timer _timer;
        
        /// <summary>
        /// Период проверки таймера
        /// </summary>
        private readonly TimeSpan _timerPeriod;
        
        /// <summary>
        /// Начальное время задержки проверки
        /// </summary>
        private readonly TimeSpan _timerDelay;

        private readonly IReminderStorage _storage;
        
        /// <summary>
        /// Создаёт объект, выполняющий логику проверки
        /// </summary>
        /// <param name="timerPeriod">Передаваемый период проверки таймера</param>
        /// <param name="timerDelay">Передаваемое начальное время задержки проверки</param>
        public ReminderSheduler(TimeSpan timerPeriod, TimeSpan timerDelay)
        {
            _timerPeriod=timerPeriod;
            _timerDelay=timerDelay;
        }

        /// <summary>
        /// Метод с логикой (таймером и пр.)
        /// </summary>
        public void Start()
        {
            _timer = new Timer(OnTimerTick, null, _timerPeriod, _timerDelay);
        }

        private void OnTimerTick(object _)
        {

        }
    }
}
