using System;

namespace Homework04
{
    class Program
    {
        // Перечисление всех цветов палитры
        [Flags]
        enum ColorAll : short   // 2 байта => 16 бит => 16 вариантов допускается
        {
            //NoneColor,      //0000_0000_0000_0000  -  0      - 0
            Black=1 ,       //0000_0000_0000_0001  -  1      - 1
            Blue    ,       //0000_0000_0000_0010  -  2      - 2
            Cyan    ,       //0000_0000_0000_0100  -  4      - 3
            Grey    ,       //0000_0000_0000_1000  -  8      - 4
            Green   ,       //0000_0000_0001_0000  -  16     - 5
            Magenta ,       //0000_0000_0010_0000  -  32     - 6
            Red     ,       //0000_0000_0100_0000  -  64     - 7
            White   ,       //0000_0000_1000_0000  -  128    - 8
            Yellow          //0000_0001_0000_0000  -  256    - 9
        };                               

        static void Main(string[] args)
        {
            // Приветствие
            Console.WriteLine("Выберите цвета из палитры для добавления в 'Избранное':");
            for (int i=0; i<9; i++) Console.WriteLine($"Цвет №{i+1} - {(ColorAll)(i+1)},");
            
            // Выбор цветов
            var colorFavorites = new byte[4];
            bool colorParsResult;

            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Добавить цвет №");
                try
                {
                    colorParsResult = byte.TryParse(Console.ReadLine(), out colorFavorites[j]);

                }
                catch
                {
                    Console.WriteLine($"Не удалось выбрать цвет, возможно введены некорректные данные.");
                }
            }

            // Вывод цветов
            Console.WriteLine("Список цветов, добавленных в 'Избранное':");
            for (int k = 0; k < 4; k++)
            {
                Console.WriteLine($"Цвет №{colorFavorites[k]} - {(ColorAll)(colorFavorites[k])}");
                //Console.WriteLine($"{(ColorAll)((byte)ColorAll.Black << (colorFavorites[k]-1))}");
            }

            Console.WriteLine($"{ColorAll.Blue | ColorAll.Cyan}");
            // эксперимент
            Console.WriteLine($"{(ColorAll)((byte)ColorAll.Black << 2)}");

        }
    }
}
