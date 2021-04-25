using System;
using System.Collections.Generic;

namespace Homework14
{
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
}
