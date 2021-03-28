using System;
using System.Text;
using System.Threading;

namespace ShporaConsole
{
    class Program
    {
        // Для № 09. Игры с преобразованиями и выводом Enum
        enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void Main(string[] args)
        {
            // Рандомное случайное число Int от 0 до 6
            var randomInt = new Random().Next(0, 6);

            // 11. Игры с текстом
            {
                // --- String ---
                var  textTest = "test string     ";
                var  textArray = textTest.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);       // получить массив слов без разднлителей, удалить пустые элементы
                var textTest2 = string.Join(" & ", textArray);          // вместо массива можно исп. его элем. через ',' // соединить массив в строку, используя разделитель
                bool txtResult = textTest.Contains(" ");                // true, содержит символ
                     txtResult = textTest.StartsWith("te");             // true, начинается с ...
                     txtResult = textTest.EndsWith("s");                // false, заканчивается ...
                     txtResult = string.IsNullOrEmpty(textTest);        // "" или Null
                     txtResult = string.IsNullOrWhiteSpace(textTest);   // пробелы или Null или ...
                int  simbolNumber = textTest.IndexOf("s");              // 2, при расчете слева
                     simbolNumber = textTest.LastIndexOf("s");          // 5, при расчете справа, но сам индекс все равно слева
                     textTest = textTest.Replace("test", "Тестовый", StringComparison.OrdinalIgnoreCase).Replace("string", "текст", StringComparison.OrdinalIgnoreCase);   // замена части текста
                     textTest = textTest.Substring(0, 15);              // взять часть строки
                     textTest = textTest.ToUpper();                     // поднять в верхний регистр
                     textTest = textTest.ToLower();                     // опустить в нижний регистр
                     textTest = textTest.Trim(new[] { ' ', '\t', '\n' }); // удалить из начала и конца строки то, что в массиве
                // --- StringBuilder ---
                var sb = new StringBuilder("ABC", 50);  // создать "массив" из 50 эл, но заполнить первые 3 элемента
                sb.Append(new[] { 'D', 'E', 'F' });     // заполнить (добавить) еще 3 элемента
                sb.AppendFormat("GHI{0}{1}", 'J', 'k');	// добавление строк подобно string.Format
                int lehgthSb = sb.Length;               // длина - заполненные (добавленные) элементы
                sb.Insert(0, "Alphabet: ");             // добавление вначале с увеличением длины
                sb.Replace('k', 'K');                   // замена 1о символа на 2й везде 
            }

            // 10. switch, как тернарный оператор (тип может быть любой)
            {
                string randomIntDes = randomInt switch
                {
                    0 => "тут ноль",
                    1 => "тут один",
                    _ => "не ноль и не один"
                };
            }

            // 09. Игры с преобразованиями и выводом Enum
            {
                WriteWithColor("\n---09---", ConsoleColor.Magenta);
                var nameDay = (Days)Enum.Parse(typeof(Days), randomInt.ToString());
                Console.WriteLine("Вывод1 имени: " + nameDay);
                //---
                var namesDay = Enum.GetNames(typeof(Days));
                for (int i = 0; i < namesDay.Length; i++) Console.WriteLine("Вывод2 имени: " + namesDay[i]);
                //---
                var valuesDay = (Days[])Enum.GetValues(typeof(Days));
                for (int i = 0; i < valuesDay.Length; i++) Console.WriteLine("Вывод3 числа: " + valuesDay[i].ToString("X"));
            }

            // 08. Метод для ввода значения double в определенном промежутке, с указанием колва знаков после запятой accuracy, с проверкой значений
            WriteWithColor("\n---08---", ConsoleColor.Magenta);
            var doubleValue = ReadInSpacingDouble(0.222, 0.999, 3, "число с 3мя знакми после запятой в пределах от 0.222 до 0.999: ");

            // 07. Метод для ввода значения double с указанием кол-ва знаков после запятой и проверкой значений
            WriteWithColor("\n---07---", ConsoleColor.Magenta);
            var doubleValueInSpacing = ReadDouble("десятичную дробь: ", 3);

            // 06. Метод для ввода значения int в определенном промежутке, с проверкой значений
            WriteWithColor("\n---06---", ConsoleColor.Magenta);
            var intValueInSpacing = ReadInSpacingInt(5, 55, "натур. число от 5 до 55: ");

            // 05. Метод для ввода значения int с проверкой значений 
            WriteWithColor("\n---05---", ConsoleColor.Magenta);
            var intValue = ReadInt("целое число: ");

            // 04. Полезные методы при использовании Nullable
            {
                WriteWithColor("\n---04---", ConsoleColor.Magenta);
                int? a; a = randomInt;
                Console.WriteLine(a.GetValueOrDefault());   // вернуть значение или default
                Console.WriteLine(a.HasValue);              // имеет ли значение?
                Console.WriteLine(a.Value);                 // само значение
            }

            // 03. Способы сравнения строк
            WriteWithColor("\n---03---", ConsoleColor.Magenta);
            Console.WriteLine("ttt".Equals("tttgh"));
            Console.WriteLine(string.Equals("ttt", "tttgh")) ;

            // 02. Метод с таймером, аргумент количество мс в типе данных int [-2 147 483 648; 2 147 483 647]
            WriteWithColor("\n---02---", ConsoleColor.Magenta);
            Timer(randomInt * 300);

            // 01. Метод вывода сообщения в цвете
            WriteWithColor("\n---01---", ConsoleColor.Magenta);
            WriteWithColor("Сообщение в зеленом цвете", ConsoleColor.Green);
        }

        //------------------------------------------------------------------//


        // 09. Метод для ввода Int с обработкой ошибок (вывод один и тот же для всех)
        static int ReadIntWithoutException(string name)
        {
            for (; ; )
            {
                Console.WriteLine($"Enter integer value {name}");
                if (int.TryParse(Console.ReadLine(), out var number))
                {
                    return number;
                }

                WriteWithColor("Entered incorrect data!", ConsoleColor.Red);
            }
        }

        // 08. Метод для ввода значения double в определенном промежутке, с указанием колва знаков после запятой accuracy, с проверкой значений
        static double ReadInSpacingDouble(double spaceMin, double spaceMax, int accuracy, string name)
        {
            double chisloDouble;
            bool readResult;
            do
            {
                chisloDouble = ReadDouble(name, accuracy);
                readResult = (chisloDouble < spaceMin) || (chisloDouble > spaceMax);

                // Проверка на соответствие промежутку
                if (readResult)
                    WriteWithColor("Введенное значение выходит за пределы допустимых.", ConsoleColor.Red);
            }
            while (readResult);
            return chisloDouble;
        }

        // 07. Метод для ввода значения double с указанием кол-ва знаков после запятой и проверкой значений
        static double ReadDouble(string name, int accuracy)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    return Math.Round(double.Parse(Console.ReadLine()), accuracy, MidpointRounding.AwayFromZero);
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)     //double.Parse()
                {
                    WriteWithColor("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
                }
                catch (OverflowException exception)             //double.Parse()
                {
                    WriteWithColor("Введенное значение выходит за пределы допустимых.\n" +
                                   "Пожалуйста введите значение в пределах от " + double.MinValue + " до " + double.MaxValue + ".\n" +
                                   exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine(), Math.Round()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentException exception)              //double.Parse(), Math.Round()
                {
                    WriteWithColor("Что-то пошло не так, возможно не удаётся распознать способ округления.\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // 06. Метод для ввода значения int в определенном промежутке, с проверкой значений
        static int ReadInSpacingInt(int spaceMin, int spaceMax, string name)
        {
            int chislo;
            bool readResult;
            do
            {
                chislo = ReadInt(name);

                // Проверка на соответствие промежутку
                readResult = (chislo < spaceMin) || (chislo > spaceMax);
                if (readResult)
                    WriteWithColor("Введенное значение выходит за пределы допустимых.", ConsoleColor.Red);

            }
            while (readResult);
            return chislo;
        }

        // 05. Метод для ввода значения int с проверкой значений
        static int ReadInt(string name)
        {
            for (; ; )
            {
                try
                {
                    Console.Write($"Введите {name}");
                    return int.Parse(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
                {
                    WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
                }
                catch (Exception exception) when (exception is ArgumentNullException || exception is FormatException)     //int.Parse()
                {
                    WriteWithColor("Не удаётся распознать число. Пожалуйста, введите число корректно.\n" + exception.Message, ConsoleColor.Red);
                }
                catch (OverflowException exception)             //int.Parse()
                {
                    WriteWithColor("Введенное значение выходит за пределы допустимых.\n" +
                                   "Пожалуйста введите значение в пределах от " + int.MinValue + " до " + int.MaxValue + ".\n" +
                                   exception.Message, ConsoleColor.Red);
                }
                catch (ArgumentException exception)              //int.Parse()
                {
                    WriteWithColor("Что-то пошло не так, возможно не удаётся распознать способ округления.\n" + exception.Message, ConsoleColor.Red);
                }
            }
        }

        // 02. Метод с таймером, аргумент количество мс в типе данных int [-2 147 483 648; 2 147 483 647]
        static void Timer(int msek)
        {
            for (; ; )
            {
                try
                {
                    Thread.Sleep(msek);
                    return;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteWithColor("Некорректное время для таймера, пожалуйста введите целое число от 0 до " + int.MaxValue + "\n" + ex.Message, ConsoleColor.Red);
                    msek = ReadInt("число милисекунд:");
                }
            }
        }

        // 01. Метод вывода сообщения в цвете
        static void WriteWithColor(string message, ConsoleColor color)
        {
            var restoreColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = restoreColor;
        }

    }
}
