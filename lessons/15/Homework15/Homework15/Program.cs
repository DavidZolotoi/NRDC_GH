using System;
using System.Collections.Generic;
using System.IO;

namespace Homework15
{
    public interface ILogWriter
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
    }

    public abstract class AbstractLogWriter : ILogWriter
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

    public class ConsoleLogWriter : AbstractLogWriter
    {
        protected override void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            Console.Write(textLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }

    public class FileLogWriter : AbstractLogWriter
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

    public class MultipleLogWriter : ILogWriter
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
        public static LogWriterFactory Instance => instance  ??= new LogWriterFactory();     // другой способ: Instance { get; } = new LogWriterFactory();
        private LogWriterFactory() {}

        // метод для [синглтонского] объекта
        public ILogWriter GetLogWriter<T>(object parameters) where T : ILogWriter               // T: ConsoleLogWriter, FileLogWriter, MultipleLogWriter
        {
            ILogWriter logWriter = default;
            if (typeof(T) == typeof(ConsoleLogWriter)) logWriter = (ILogWriter)(new ConsoleLogWriter());
            if (typeof(T) == typeof(FileLogWriter)) logWriter = (ILogWriter)(new FileLogWriter(parameters.ToString()));
            if (typeof(T) == typeof(MultipleLogWriter)) logWriter = (ILogWriter)(new MultipleLogWriter((List<ILogWriter>)parameters));
            return logWriter;
        }

        // аналогичный статический метод
        public static ILogWriter GetLogWriterStatic<T>(object parameters) where T : ILogWriter               // T: ConsoleLogWriter, FileLogWriter, MultipleLogWriter
        {
            ILogWriter logWriter = default;
            if (typeof(T) == typeof(ConsoleLogWriter)) logWriter = (ILogWriter)(new ConsoleLogWriter());
            if (typeof(T) == typeof(FileLogWriter)) logWriter = (ILogWriter)(new FileLogWriter(parameters.ToString()));
            if (typeof(T) == typeof(MultipleLogWriter)) logWriter = (ILogWriter)(new MultipleLogWriter((List<ILogWriter>)parameters));
            return logWriter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //--- Работа метода внутри синглтонского объекта ---//
            var logger1 = LogWriterFactory.Instance.GetLogWriter<ConsoleLogWriter>(null);                                           // объект ConsoleLogWriter
            var logger2 = LogWriterFactory.Instance.GetLogWriter<FileLogWriter>("logs");                                            // объект FileLogWriter
            var logger3 = LogWriterFactory.Instance.GetLogWriter<MultipleLogWriter>(new List<ILogWriter>() { logger1, logger2 });   // объект MultipleLogWriter

            logger1.LogError("вывод Error на консоль");
            logger2.LogInfo("вывод Info в файл");
            logger3.LogWarning("вывод Warning и в консоль и в файл");

            // Аналог со статическим методом
            var logger4 = LogWriterFactory.GetLogWriterStatic<ConsoleLogWriter>(null);                                           // объект ConsoleLogWriter
            var logger5 = LogWriterFactory.GetLogWriterStatic<FileLogWriter>("logs");                                            // объект FileLogWriter
            var logger6 = LogWriterFactory.GetLogWriterStatic<MultipleLogWriter>(new List<ILogWriter>() { logger1, logger2 });   // объект MultipleLogWriter

            logger4.LogError("вывод Error на консоль (стат.метод)");
            logger5.LogInfo("вывод Info в файл (стат.метод)");
            logger6.LogWarning("вывод Warning и в консоль и в файл (стат.метод)");


        }
    }
}
