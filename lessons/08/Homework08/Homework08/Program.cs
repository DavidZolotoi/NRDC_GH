using System;
using System.Collections.Generic;

namespace Homework08
{
    class Program
    {
        static void Main(string[] args)
        {
            // Метод ввода строки со всеми проверками
            var textCR = Console.ReadLine();

            // Соответствие закрывающих скобок открывающим
            var textDict = new Dictionary<char, char>
            {
                ['('] = ')',
                ['['] = ']',
                ['{'] = '}',
                ['<'] = '>'
            };

            // все проверки строки textCR уже сделаны
            var textStack = new Stack<char>(); int i = 0;
            foreach (var s in textCR)
            {
                if (s == '(' || s == '[') textStack.Push(s);
                if ((s == ')' || s == ']') && s == textDict[textStack.Peek()]) { textStack.Pop(); Console.WriteLine($"{i} - ok"); }
                i++;
            }
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