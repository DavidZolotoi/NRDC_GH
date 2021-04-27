using System;

namespace Homework14
{
    abstract class AbstractLogWriter : ILogWriter
    {
        public virtual void LogError(string message)
        {
            Log("Error", message);
        }

        public virtual void LogInfo(string message)
        {
            Log("Info", message);
        }

        public virtual void LogWarning(string message)
        {
            Log("Warning", message);
        }

        protected virtual void Log(string typeLog, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");
            Writer($"{DateTimeOffset.UtcNow:O}\t{typeLog}\t{ message}\n");
        }

        protected virtual void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
        }
    }
}
