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
            //var textCR = "()";              // True
            //var textCR = "[]()";            // True
            //var textCR = "[[]()]";          // True
            //var textCR = "([([])])()[]";    // True
            //var textCR = "(";               // False
            //var textCR = "[][)";            // False
            //var textCR = "[(])";            // False
            var textCR = "(()[]]";          // False

            // все проверки строки textCR на корректность исходных данных уже сделаны выше.
            var stackSkobky = new Stack<char>();
            bool bPeek, bKeyValue, bPop, bResult = false;
            char peek, stackPeekDict, stackPop;
            foreach (var s in textCR)
            {
                if (dictSkobky.ContainsKey(s))           // 1. ЕСЛИ текущий символ относится к ключам (открывающим скобкам)
                {                                                                                               // ТО
                    stackSkobky.Push(s);                                                                        // То положить на стек открывающую скобку, ждущую закрытия
                    bResult = true;                                                                             // И зафиксировать факт того, что в стек положили открывающую скобку
                }
                else if (dictSkobky.ContainsValue(s))    // 2. ЕСЛИ текущий символ относится к значениям (закрывающим скобкам)
                {                                                                                               // ТО
                    if (stackSkobky.Count == 0) bResult = false;                                                // зафиксировать факт того, что есть закрывающие, а открывающих в стеке нет
                    bPeek = stackSkobky.TryPeek(out peek);                                                      // Получилось ли получить значение открывающей скобки на стеке? Если нет, занчит - else
                    bKeyValue = dictSkobky.TryGetValue(peek, out stackPeekDict);                                // Получилось ли найти для неё значение закрывающей скобки из словаря? Если нет, занчит - else
                    if ((s == stackPeekDict) && bPeek && bKeyValue) bPop = stackSkobky.TryPop(out stackPop);    // Если всё получилось и текущая закрывающая скобка совпадает со значением из словаря. Если нет, занчит - else
                    //Console.WriteLine($"тек.символ {s}, на стеке {peek}, значение из словаря {stackPeekDict}");
                }
            }

            // Вывод
            if (bResult && stackSkobky.Count == 0)    // ЕСЛИ значений в стеке не осталось и нет лишних закрывающих скобок, то всё ок
                WriteWithColor("Порядок и количество скобок верные.", ConsoleColor.Green);
            else                                      // ИНАЧЕ, либо есть закрывающие, но нет открывающих (bResult=false), либо наоборот (stackSkobky.Count>0), либо и то и другое
                WriteWithColor("В порядке или количестве скобок есть ошибка.", ConsoleColor.Red);
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
