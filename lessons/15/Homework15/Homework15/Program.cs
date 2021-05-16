using System;
using System.Collections.Generic;
using System.IO;

namespace Homework15
{
    interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }

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

    class ConsoleLogWriter : AbstractLogWriter
    {
        protected override void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            Console.Write(textLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    class FileLogWriter : AbstractLogWriter
    {
        private string DirName { get; set; }

        public FileLogWriter(string dirName)
        {
            if (string.IsNullOrEmpty(dirName))
                throw new ArgumentException("Некорректное наименование каталога для логов.");
            DirName = dirName;
            if (!Directory.Exists(DirName)) Directory.CreateDirectory(DirName);
            //if (!File.Exists($"{DirName}\\logs.txt")) { var fileLogs = File.Create($"{DirName}\\logs.txt"); fileLogs.Close(); }   // не нужно т.к. File.AppendAllText(@"logs\logs.txt", textLog) умеет создавать
        }

        protected override void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            File.AppendAllText($"{DirName}\\logs.txt", textLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    class MultipleLogWriter : ILogWriter
    {
        List<ILogWriter> LogList { get; set; }

        public MultipleLogWriter(List<ILogWriter> logList)
        {
            if (logList == null)
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

    // класс, реализующий паттерн Синглтон
    public class LogWriterFactory
    {
        private static LogWriterFactory instance;
        public static LogWriterFactory Instance; // => instance ??= new LogWriterFactory();     // другой способ: Instance { get; } = new LogWriterFactory();
        private LogWriterFactory(){}

        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter               // T: ConsoleLogWriter, FileLogWriter, MultipleLogWriter
        {
            Instance = instance ??= new T();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Коллекция объектов классов, реализующих интерфейс ILogWriter
            var logList = new List<ILogWriter>()
            {
                new FileLogWriter("logs"),
                new ConsoleLogWriter(),
            };

            logList[0].LogError("FileLogWriter-Error");         // эти три записи пойдут в файл
            logList[1].LogWarning("ConsoleLogWriter-Warning");  // эти три записи пойдут на консоль

            Console.WriteLine();

            var logMultiple = new MultipleLogWriter(logList);
            // методы, реализации которых зависят от класса элемента коллекции // пробегаются по всем элементам коллекции
            logMultiple.LogError("MultipleLogWriter-Error");        // 1 запсисm в файлm + 1 записm на косноль = 2 заданных элементов коллекции
            logMultiple.LogInfo("MultipleLogWriter-Info");          // 1 запсисm в файлm + 1 записm на косноль = 2 заданных элементов коллекции
            logMultiple.LogWarning("MultipleLogWriter-Warning");    // 1 запсисm в файлm + 1 записm на косноль = 2 заданных элементов коллекции
                                                                    // итого 6 записей = 3 в файле + 3 на консоль

            GetLogWriter<ConsoleLogWriter>(LogWriterFactory.);

        }
    }
}
