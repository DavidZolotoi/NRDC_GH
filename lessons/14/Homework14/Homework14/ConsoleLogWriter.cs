using System;

namespace Homework14
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        protected override void Writer(string textLog)
        {
            if (string.IsNullOrWhiteSpace(textLog))
                throw new ArgumentException("Некорректное сообщение для лога.");
            Console.Write(textLog);
        }   // проверка лишняя (задублированная), но сделана для самомтоятельности метода, с расчетом на будущие изменения кода
    }
}
