using System;
using System.Collections.Generic;

namespace Homework14
{
    class MultipleLogWriter : ILogWriter
    {
        List<ILogWriter> LogList { get; set; }

        public MultipleLogWriter(List<ILogWriter> logList)
        {
            if (logList==null)
                throw new ArgumentException("Некорректная коллекция логов.");
            LogList = logList;
        }
        
        public void LogInfo(string message)
        {
            LogWriter("Info", message);
        }

        public void LogWarning(string message)
        {
            LogWriter("Warning", message);
        }

        public void LogError(string message)
        {
            LogWriter("Error", message);
        }

        public void LogWriter(string typeLog, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");

            string textLog = $"{DateTimeOffset.UtcNow:O}\t{typeLog}\t{ message}\n";

            foreach (var item in LogList)
                     if (item.GetType() == typeof(FileLogWriter))    ((FileLogWriter)item).Writer(textLog);
                else if (item.GetType() == typeof(ConsoleLogWriter)) ((ConsoleLogWriter)item).Writer(textLog);
                else throw new ArgumentException("Неизвестный тип записи лога");
        }

    }
}
