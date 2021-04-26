using System;
using System.IO;

namespace Homework14
{
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

        public override void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            File.AppendAllText($"{DirName}\\logs.txt", textLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }
}
