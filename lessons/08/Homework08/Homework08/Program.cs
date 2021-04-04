﻿using System;
using System.Collections.Generic;

namespace Homework08
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

            // Метод для ввода строки со всеми проверками, получающий допустимые значения и возвращающий изменённую строку только из допустимых
            var textCR = ReadString("выражение для проверки, содержащее скобки: ", dictSkobky);

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

        // Метод для ввода строки со всеми проверками, получающий допустимые значения и возвращающий изменённую строку только из допустимых
        static string ReadString(string name, Dictionary<char, char> dict)
        {
            string text;
            for (; ; )
            {
                try
                {
                    Console.Write("\nСписок важных скобок: ");
                    foreach (var item in dict.Keys) Console.Write(item);
                    foreach (var item in dict.Values) Console.Write(item);
                    Console.Write($"\nВведите {name}");
                    text = Console.ReadLine();

                    // проверка на пустоту
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        WriteWithColor("Вы не ввели ни одной скобки из перечисленных выше. Пожалуйста, попробуйте еще раз.", ConsoleColor.Red);
                        continue;
                    }

                    return text;
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
            }
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

// Немного поигрался с Console.ReadKey();
//ConsoleKeyInfo klav;
//do
//{
//    klav = Console.ReadKey();
//    if (klav.KeyChar == '(' || klav.KeyChar == '[' || klav.KeyChar == ')' || klav.KeyChar == ']')
//    {
//        textCR += klav.KeyChar;
//        continue;
//    }

//    if (klav.Key != ConsoleKey.Enter)
//    {
//        Console.WriteLine(
//            $"\n\'{klav.KeyChar}\' - Недопустимый символ." +
//            "\nПродолжайте вводить один из следующих символов: \'(\', \')\', \'[\', \']\'. Затем нажмите клавишу ввода." +
//            $"\nНа данный момент введено \'{textCR}\'"
//            );
//    }
//}
//while (klav.Key != ConsoleKey.Enter) ;