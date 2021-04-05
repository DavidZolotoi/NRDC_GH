using System;
using System.Collections.Generic;

namespace Homework08_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Соответствие закрывающих скобок (значений) открывающим (ключам)
            var dictSkobky = new Dictionary<char, char>
            {
                ['('] = ')',
                ['['] = ']',
                ['{'] = '}',
                ['<'] = '>'
            };

            // Варианты для проверки
            var variant = new string[]
                {
                "()",                           // True
                "[]()",                         // True
                "[[]()]",                       // True
                "([([])])()[]",                 // True
                "(",                            // False
                "[][)",                         // False
                "[(])",                         // False
                "(()[]]",                       // False
                "0.5*(x*x+[cos{b}*2-5<r-p>])+1" // True
                };

            // Проверка вариантов в массиве
            foreach (var item in variant)
            {
                Console.WriteLine($"В выражении: {item}");
                if (getResult(item, dictSkobky))        // ЕСЛИ вернул true
                    WriteWithColor("Порядок и количество скобок верные.", ConsoleColor.Green);
                else                                      // ИНАЧЕ вернул false
                    WriteWithColor("Порядок и количество скобок неверные.", ConsoleColor.Red);
                Console.WriteLine();
            }
        }

        // Метод - суть программы - проверка выражения на правильность
        static bool getResult(string textCR, Dictionary<char, char> dictSkobky)
        {
            // все проверки строки textCR на корректность исходных данных уже сделаны выше.
            var stackSkobky = new Stack<char>();
            bool getPop;
            char stackPopDict, stackPop;
            foreach (var s in textCR)
            {
                if (dictSkobky.ContainsKey(s))                                              // 1. ЕСЛИ текущий символ относится к ключам (открывающим скобкам)
                    stackSkobky.Push(s);                                                                // ТО положить на стек открывающую скобку, ждущую закрытия
                else if (dictSkobky.ContainsValue(s))                                       // 2. ЕСЛИ текущий символ относится к значениям (закрывающим скобкам)
                {                                                                                       // ТО
                    getPop = stackSkobky.TryPop(out stackPop);                                          // скидываем со стека лежащую сверху открывающую скобку (ключ для словаря)
                    if (!(dictSkobky.TryGetValue(stackPop, out stackPopDict) && s == stackPopDict))     // находим для нее закрывающую скобку из словаря (значение из словаря)
                        return false;                                                     // если они не совпадают, значит выражение неверно
                }
            }

            // ЕСЛИ значений в стеке не осталось и нет лишних закрывающих скобок, то всё ок
            // ИНАЧЕ, либо есть закрывающие, но нет открывающих, либо наоборот, либо и то и другое
            return stackSkobky.Count == 0;
        }

        // Метод вывода сообщения в цвете
        static void WriteWithColor(string message, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = restoreColor;
        }

    }
}
