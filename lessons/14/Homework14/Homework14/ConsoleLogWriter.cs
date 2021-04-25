using System;

namespace Homework14
{
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
}
