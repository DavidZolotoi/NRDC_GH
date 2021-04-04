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
            bool getPeek, getKeyValue, getPop, getStackStatus = false;
            char peek, stackPeekDict, stackPop;
            foreach (var s in textCR)
            {
                if (dictSkobky.ContainsKey(s))           // 1. ЕСЛИ текущий символ относится к ключам (открывающим скобкам)
                {                                                                                                   // ТО
                    stackSkobky.Push(s);                                                                            // То положить на стек открывающую скобку, ждущую закрытия
                    getStackStatus = true;                                                                          // И зафиксировать факт того, что в стек положили открывающую скобку
                }
                else if (dictSkobky.ContainsValue(s))    // 2. ЕСЛИ текущий символ относится к значениям (закрывающим скобкам)
                {                                                                                                   // ТО
                    if (stackSkobky.Count == 0) getStackStatus = false;                                             // зафиксировать факт того, что есть закрывающие, а открывающих в стеке нет
                    getPeek = stackSkobky.TryPeek(out peek);                                                        // Получилось ли получить значение открывающей скобки на стеке? Если нет, занчит - else
                    getKeyValue = dictSkobky.TryGetValue(peek, out stackPeekDict);                                  // Получилось ли найти для неё значение закрывающей скобки из словаря? Если нет, занчит - else
                    if ((s == stackPeekDict) && getPeek && getKeyValue) getPop = stackSkobky.TryPop(out stackPop);  // Если всё получилось и текущая закрывающая скобка совпадает со значением из словаря. Если нет, занчит - else
                    //Console.WriteLine($"тек.символ {s}, на стеке {peek}, значение из словаря {stackPeekDict}");
                }
            }

            // ЕСЛИ значений в стеке не осталось и нет лишних закрывающих скобок, то всё ок
            // ИНАЧЕ, либо есть закрывающие, но нет открывающих (bResult=false), либо наоборот (stackSkobky.Count>0), либо и то и другое
            return getStackStatus && stackSkobky.Count == 0;
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
