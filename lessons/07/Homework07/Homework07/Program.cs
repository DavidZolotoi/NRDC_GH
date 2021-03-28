using System;

namespace Homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            // ввод, сплит с проверкой исключений, цикл для проверки количества слов
            string text; string[] textArray;
            do
            {
                text = ReadString("текст (минимум 2 слова) и нажмите клавишу ввода: ");
                textArray = SplitText(text);
                if (textArray.Length < 2) WriteWithColor("Слишком мало слов. Введите как минимум 2 слова.", ConsoleColor.Red);
            }
            while (textArray.Length<2);

            // проверка массива на слова, начинающиеся в "А"
            int quantity = 0;
            foreach (string txt in textArray)
            {
                // т.к. в коде считаются только слова, то с помощью условия && txt.Length>1 отсекаем предлоги "а"
                if (txt.StartsWith("А", StringComparison.InvariantCultureIgnoreCase) && txt.Length>1) quantity++;
            }
            Console.WriteLine($"Количество слов, начинающихся с буквы \"А\": {quantity}");
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

        // Метод для ввода текста с обработкой ошибок
        static string ReadString(string name)
        {
            for ( ; ; )
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
