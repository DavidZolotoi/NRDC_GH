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
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");
            foreach (var item in LogList) item.LogInfo(message);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода

        public void LogWarning(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");
            foreach (var item in LogList) item.LogWarning(message);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода

        public void LogError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Некорректное сообщение для лога.");
            foreach (var item in LogList) item.LogError(message);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }
}
