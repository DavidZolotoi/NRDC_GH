using System;
using System.Text;

namespace Homework07_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                ReverseString(
                        ReadString("непустую строку, содержащую хотя бы 1 печатную букву: ")
                    ).ToLower()
                    );
        }

        // Метод для отражения string с помощью массива StringBuilder
        static string ReverseString(string textString)
        {
            var textStringBuilder = new StringBuilder(textString, 500);
            int lehgthSb = textStringBuilder.Length;
            char tempSb;
            for (int i = 0; i < lehgthSb / 2; i++)
            {
                tempSb = textStringBuilder[i];
                textStringBuilder[i] = textStringBuilder[lehgthSb - i - 1];
                textStringBuilder[lehgthSb - i - 1] = tempSb;
            }
            return textStringBuilder.ToString();              //string.Join("", textStringBuilder);
        }

        // Метод для ввода текста с проверкой на пустоту, печатные буквы, обработкой искл. и возвратом текста
        static string ReadString(string name)
        {
            string textCR; bool pustoi;
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    textCR = Console.ReadLine();

                    // Проверка на пустоты
                    pustoi = string.IsNullOrWhiteSpace(textCR);
                    if (pustoi)
                    {
                        WriteWithColor("Введенный текст пустой.", ConsoleColor.Red);
                        continue;
                    }

                    // Проверка на наличие букв и печатных букв
                    bool bukva = false, pechatnie = false;
                    foreach (var s in textCR)
                    {
                        // Проверка на наличие букв
                        if (char.IsLetter(s)) bukva |= true;        // bukva = char.IsLetter(s) ? bukva |= true : bukva;
                        // Проверка на наличие печатных
                        if (bukva) pechatnie |= char.IsUpper(s);    // pechatnie = char.IsWhiteSpace(s) ? pechatnie : pechatnie |= char.IsUpper(s);
                    }
                    if (!bukva)
                    {
                        WriteWithColor("Введенный текст не имеет букв алфавита.", ConsoleColor.Red);
                        continue;
                    }
                    if (!pechatnie)
                    {
                        WriteWithColor("Введенный текст не имеет печатных букв.", ConsoleColor.Red);
                        continue;
                    }
                    return textCR;
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

        //// Метод для отражения string с помощью массива StringBuilder
        //static string ReverseString(string textString)
        //{
        //    try
        //    {
        //        var textStringBuilder = new StringBuilder(textString, 500);
        //        int lehgthSb = textStringBuilder.Length;
        //        char tempSb;
        //        for (int i = 0; i < lehgthSb / 2; i++)
        //        {
        //            tempSb = textStringBuilder[i];
        //            textStringBuilder[i] = textStringBuilder[lehgthSb - i - 1];
        //            textStringBuilder[lehgthSb - i - 1] = tempSb;
        //        }
        //        return textStringBuilder.ToString();              //string.Join("", textStringBuilder);
        //    }
        //    catch (ArgumentOutOfRangeException exception)
        //    {
        //        WriteWithColor("Что-то пошло не так. Возможно слишком большое количество символов, но это не точно.\n" + exception.Message, ConsoleColor.Red);
        //        return "-1";
        //    }
        //}

        //// Метод разбивки текста на массив по разделителям с обработкой исключений
        //static string[] SplitText(string text)
        //{
        //    for (; ; )
        //    {
        //        try
        //        {
        //            return text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //        }
        //        catch (ArgumentException exception)
        //        {
        //            WriteWithColor("Что-то пошло не так, попробуйте ввести что-нибудь другое.\n" + exception.Message, ConsoleColor.Red);
        //        }
        //    }
        //}

        //// Метод для ввода String с обработкой ошибок
        //static string ReadString(string name)
        //{
        //    for (; ; )
        //    {
        //        try
        //        {
        //            Console.Write($"Введите {name}");
        //            return Console.ReadLine();
        //        }
        //        catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
        //        {
        //            WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
        //        }
        //    }
        //}

    }
}
