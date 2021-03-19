using System;

namespace Homework04
{
    class Program
    {
        // Перечисление всех цветов палитры
        [Flags]
        enum ColorAll : short   // 2 байта => 16 бит => 16 вариантов допускается
        {
            N0_NoneColor = 0x0     ,       //0000_0000_0000_0000  -    0    - 0
            N1_Black     = 0x1     ,       //0000_0000_0000_0001  -    1    - 1
            N2_Blue      = 0x1 << 1,       //0000_0000_0000_0010  -    2    - 2
            N3_Cyan      = 0x1 << 2,       //0000_0000_0000_0100  -    4    - 3
            N4_Grey      = 0x1 << 3,       //0000_0000_0000_1000  -    8    - 4
            N5_Green     = 0x1 << 4,       //0000_0000_0001_0000  -   16    - 5
            N6_Magenta   = 0x1 << 5,       //0000_0000_0010_0000  -   32    - 6
            N7_Red       = 0x1 << 6,       //0000_0000_0100_0000  -   64    - 7
            N8_White     = 0x1 << 7,       //0000_0000_1000_0000  -  128    - 8
            N9_Yellow    = 0x1 << 8        //0000_0001_0000_0000  -  256    - 9
        };

        static void Main(string[] args)
        {
            // Console.WriteLine(Convert.ToString(0x1 << 2, 2));

            // Приветствие
            Console.WriteLine("Выберите цвета из палитры для добавления в 'Избранное':");

            // Через while и игру с битами
            ColorAll a =ColorAll.N1_Black;
            while (a <= ColorAll.N9_Yellow)
            {
                Console.WriteLine($"Цвет {a},");
                a = (ColorAll)((short)a << 1);
                Console.WriteLine(ColorAll.N9_Yellow);
            }

            // Выбор цветов
            var colorFavorites = new short[4];
            var b = ColorAll.N0_NoneColor;

            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Добавить цвет №");
                try
                {
                    // colorParsResult = short.TryParse(Console.ReadLine(), out colorFavorites[j]);
                    colorFavorites[j] = short.Parse(Console.ReadLine());
                    b = b | (ColorAll)((short)colorFavorites[j]);
                    Console.WriteLine(b);
                }
                catch
                {
                    Console.WriteLine($"Не удалось выбрать цвет, возможно введены некорректные данные.");
                }
            }

            Console.WriteLine($"b = {b}");

            // Вывод цветов
            Console.WriteLine("Список цветов, добавленных в 'Избранное':");
            for (int k = 0; k < 4; k++)
            {
                Console.WriteLine($"Цвет №{colorFavorites[k]} - {(ColorAll)(colorFavorites[k])}");
                //Console.WriteLine($"{(ColorAll)((byte)ColorAll.Black << (colorFavorites[k]-1))}");
            }

            // Console.WriteLine($"{ColorAll.N2_Blue | ColorAll.N3_Cyan}");
            // эксперимент
            // Console.WriteLine($"{(ColorAll)((short)ColorAll.N1_Black << 2)}");

        }
    }
}
