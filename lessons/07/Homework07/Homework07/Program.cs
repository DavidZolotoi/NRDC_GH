using System;

namespace Homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            // ввод, сплит с проверкой исключений, цикл для проверки количества слов
            string[] textArray;
            do
            {
                textArray = ReadSplitString("текст (минимум 2 слова) и нажмите клавишу ввода: ");
                if (textArray.Length < 2) WriteWithColor("Слишком мало слов. Введите как минимум 2 слова.", ConsoleColor.Red);
            }
            while (textArray.Length<2);

            // проверка массива на слова, начинающиеся в "А"    // т.к. в коде считаются только слова, то с помощью условия && txt.Length>1 отсекаем предлоги "а"
            int quantity = 0;
            foreach (string txt in textArray)
                if (txt.StartsWith("А", StringComparison.InvariantCultureIgnoreCase) && txt.Length>1) quantity++;

            Console.WriteLine($"Количество слов, начинающихся с буквы \"А\": {quantity}");
        }

        // Метод для ввода текста с проверкой на пустоту, обработкой искл. и возвратом массива слов
        static string[] ReadSplitString(string name)
        {
            string text;
            bool pustoi;
            for ( ; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    text = Console.ReadLine();
                    pustoi = string.IsNullOrWhiteSpace(text);
                    if (pustoi)
                    {
                        WriteWithColor("Введенный текст не имеет смысла.", ConsoleColor.Red);
                        continue;
                    }
                    return text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentException exception)             // .Split()
                {
                    WriteWithColor("Что-то пошло не так, попробуйте ввести что-нибудь другое.\n" + exception.Message, ConsoleColor.Red);
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
