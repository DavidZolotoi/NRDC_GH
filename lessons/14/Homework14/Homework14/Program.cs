using System;
using System.Collections.Generic;
using System.IO;

namespace Homework14
{
    interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }

    abstract class AbstractLogWriter : ILogWriter
    {
        public virtual string TextLog { get; set; }
        public virtual string DateNow { get; set; }

        public AbstractLogWriter()
        {
            DateNow = $"{DateTimeOffset.UtcNow:O}";
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
                TextLog = $"{DateNow}\t{typeLog}\t{ message}\n";
            Writer(TextLog);
        }

        abstract public void Writer(string textLog);
    }

    class FileLogWriter : AbstractLogWriter
    {
        public FileLogWriter()
        {
            if (!Directory.Exists(@"logs")) Directory.CreateDirectory(@"logs");
            if (!File.Exists(@"logs\logs.txt")) { var fileLogs = File.Create(@"logs\logs.txt"); fileLogs.Close(); }
        }

        public override void Writer(string TextLog)
        {
            if (string.IsNullOrWhiteSpace(TextLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            else
                File.AppendAllText(@"logs\logs.txt", TextLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    class ConsoleLogWriter : AbstractLogWriter
    {
        public override void Writer(string TextLog)
        {
            if (string.IsNullOrWhiteSpace(TextLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            else
                Console.Write(TextLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    class MultipleLogWriter : AbstractLogWriter
    {
        public List<AbstractLogWriter> LogList { get; set; }

        public MultipleLogWriter(List<AbstractLogWriter> logList)
        {
            if (logList.Count==0)
                throw new ArgumentException("Некорректная коллекция логов.");
            else
                LogList = logList;
        }
        
        public override void Writer(string TextLog)
        {
            if (string.IsNullOrWhiteSpace(TextLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            else
                foreach (var item in LogList) item.Writer(TextLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logList = new List<AbstractLogWriter>()
            {
                new FileLogWriter(),
                new FileLogWriter(),
                new FileLogWriter(),
                new ConsoleLogWriter(),
                new ConsoleLogWriter(),
                new ConsoleLogWriter(),
            };

            logList[0].LogError("FileLogWriter-Error");         // эти три записи пойдут в файл
            logList[1].LogInfo("FileLogWriter-Info");           // эти три записи пойдут в файл
            logList[2].LogWarning("FileLogWriter-Warning");     // эти три записи пойдут в файл
            logList[3].LogError("ConsoleLogWriter-Error");      // эти три записи пойдут на консоль
            logList[4].LogInfo("ConsoleLogWriter-Info");        // эти три записи пойдут на консоль
            logList[5].LogWarning("ConsoleLogWriter-Warning");  // эти три записи пойдут на консоль

            Console.WriteLine("");

            var logMultiple = new MultipleLogWriter(logList);
            // методы, реализации которых зависят от класса элемента коллекции // пробегаются по всем элементам коллекции
            logMultiple.LogError("MultipleLogWriter-Error");        // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
            logMultiple.LogInfo("MultipleLogWriter-Info");          // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
            logMultiple.LogWarning("MultipleLogWriter-Warning");    // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
                                                                    // итого 18 записей = 9 в файле + 9 на консоль
        }
    }
}
