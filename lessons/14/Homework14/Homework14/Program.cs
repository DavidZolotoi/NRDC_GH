using System;
using System.Collections.Generic;

namespace Homework14
{
    class Program
    {
        static void Main(string[] args)
        {
            // Коллекция объектов классов, реализующих интерфейс ILogWriter
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

            Console.WriteLine();

            var logMultiple = new MultipleLogWriter(logList);
            // методы, реализации которых зависят от класса элемента коллекции // пробегаются по всем элементам коллекции
            logMultiple.LogError("MultipleLogWriter-Error");        // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
            logMultiple.LogInfo("MultipleLogWriter-Info");          // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
            logMultiple.LogWarning("MultipleLogWriter-Warning");    // 3 запсиси в файле + 3 записи на косноль = 6 заданных элементов коллекции
                                                                    // итого 18 записей = 9 в файле + 9 на консоль
        }
    }
}
