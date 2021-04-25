using System;
using System.IO;

namespace Homework14
{
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
}
