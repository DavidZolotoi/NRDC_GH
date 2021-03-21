using System;

namespace Homework04
{
    class Program
    {
        // Перечисление всех цветов палитры
        [Flags]
        enum Color : short   // 2 байта => 16 бит => 16 вариантов допускается
        {
            // цвет     в 16-й с.ч.       в 2-й с.ч.             в 10-й    №
            NoneColor = 0x0     ,       //0000_0000_0000_0000  -    0    - 0
            Black     = 0x1     ,       //0000_0000_0000_0001  -    1    - 1
            Blue      = 0x1 << 1,       //0000_0000_0000_0010  -    2    - 2
            Cyan      = 0x1 << 2,       //0000_0000_0000_0100  -    4    - 3
            Grey      = 0x1 << 3,       //0000_0000_0000_1000  -    8    - 4
            Green     = 0x1 << 4,       //0000_0000_0001_0000  -   16    - 5
            Magenta   = 0x1 << 5,       //0000_0000_0010_0000  -   32    - 6
            Red       = 0x1 << 6,       //0000_0000_0100_0000  -   64    - 7
            White     = 0x1 << 7,       //0000_0000_1000_0000  -  128    - 8
            Yellow    = 0x1 << 8        //0000_0001_0000_0000  -  256    - 9
        };

        static void Main(string[] args)
        {
            // Приветствие
            Console.WriteLine("Выберите цвета из палитры для добавления в 'Избранное':");

            // Выдача списка через игру с битами, for и одну переменную color, которая как итератор, так и выводимое значение
            // colorAll - это просто сбор всех цветов в одной переменной
            Color colorAll = Color.NoneColor;
            for (Color color = Color.Black; color <= Color.Yellow; color = (Color)((short)color << 1))
            {
                colorAll |= color;
                Console.WriteLine($"Цвет: {color},");
            }

            // Запись избранного через игру с битами, for и одну переменную
            Color colorFavorites = Color.NoneColor;
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Добавить цвет №");
                try
                {
                    colorFavorites = (Color)((short)colorFavorites | (short)Math.Pow(2, short.Parse(Console.ReadLine()) - 1));    // т.к. пользователь вводит №, а программа принимает 2^(№-1)
                }
                catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    Console.WriteLine("Введены некорректные данные, введите еще раз");
                    j -= 1;     // уменьшение счётчика, чтоб дать пользователю еще один шанс ввести корректные данные
                }
            }

            // Определение списка НЕ избранных цветов
            Color colorNotFavorites = colorAll ^ colorFavorites;

            // Выдача списков избранных и НЕ... - списков
            Console.WriteLine($"Список избранных цветов: {colorFavorites}");
            Console.WriteLine($"Список не избранных цветов: {colorNotFavorites}");
        }
    }
}


// Выдача списка через игру с битами, while и одну переменную color, colorAll - это просто сбор всех цветов в одной переменной
//Color color = Color.Black,
//      colorAll = Color.NoneColor;
//while (color <= Color.Yellow)
//{
//    colorAll |= color;
//    Console.WriteLine($"Цвет: {color},");
//    color = (Color)((short)color << 1);
//}