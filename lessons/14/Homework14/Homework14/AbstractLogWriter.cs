using System;

namespace Homework14
{
    abstract class AbstractLogWriter : ILogWriter
    {
        public string DateNow { get; set; }

        public AbstractLogWriter()
        {
            DateNow = $"{DateTimeOffset.UtcNow:O}";     // фиксация даты и времени создания лога
        }

        public virtual void LogError(string message)
        {
            CreateTextLog("Error", message);
        }

        public virtual void LogInfo(string message)
        {
            CreateTextLog("Info", message);
        }

        public virtual void LogWarning(string message)
        {
            CreateTextLog("Warning", message);
        }

        public virtual void CreateTextLog(string typeLog, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");
            else
                Writer($"{DateNow}\t{typeLog}\t{ message}\n");
        }

        abstract public void Writer(string textLog);
    }
}
