using System;
using System.Text;

namespace Homework07_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                              ReverseString( ReadStringNotEmpty("непустую строку, содержащую хотя бы 1 печатную букву: ") ).ToLower()
                             );
        }

        // Метод для отражения string с помощью массива StringBuilder
        static string ReverseString(string textString)
        {
            for (; ; )
            {
                try
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
                    return string.Join("", textStringBuilder);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    WriteWithColor("Что-то пошло не так. Возможно слишком большое количество символов, но это не точно.\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // Метод для ввода непустой строки с доп.проверкой на наличие печатных букв
        static string ReadStringNotEmpty(string cwTxt)
        {
            string textString;
            for (; ; )
            {
                textString = ReadString(cwTxt);
                // проверка на пустоту
                if (string.IsNullOrWhiteSpace(textString))
                {
                    WriteWithColor("Введенный текст пустой.", ConsoleColor.Red);
                    continue;
                }
                // проверка на наличие печатных букв
                if (textString == textString.ToLower())
                {
                    WriteWithColor("Введенный текст не имеет ни одной печатной буквы.", ConsoleColor.Red);
                    continue;
                }
                return textString;
            }
        }

        // Метод разбивки текста на массив по разделителям с обработкой исключений
        static string[] SplitText(string text)
        {
            for (; ; )
            {
                try
                {
                    return text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
                catch (ArgumentException exception)
                {
                    WriteWithColor("Что-то пошло не так, попробуйте ввести что-нибудь другое.\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // Метод для ввода String с обработкой ошибок
        static string ReadString(string name)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    return Console.ReadLine();
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
