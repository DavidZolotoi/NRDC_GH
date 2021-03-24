using System;

namespace Homework05
{
    class Program
    {
		// Список фигур
		enum Figure { Сircle=1,	Triangle, Rectangle }

		static void Main(string[] args)
		{
			// Проверка на ввод в рамках [0..10] - int
			int accuracyCalculation;
			bool accurCalcReadResult;
			do
			{ 
				accuracyCalculation = (int)ReadDouble("точность расчётов (количество знаков после запятой (от 0 до 10)):", 0);
				accurCalcReadResult = (accuracyCalculation<0) || (accuracyCalculation>10);
				if (accurCalcReadResult)
					WriteWithColor("Введенное значение выходит за пределы допустимых.", ConsoleColor.Red);
			}
			while (accurCalcReadResult) ;

			Console.WriteLine("Список фигур:\n1. Круг,\n2. Равносторонний треугольник,\n3. Прямоугольник.");

			var figure = ReadEnum("фигуру (№ от 1 до 3 или наименование):");

			switch (figure)
            {
				case Figure.Сircle:
                    Console.WriteLine("Выбрана окружность:");
					double r = ReadDouble("радиус:", accuracyCalculation);
					Console.WriteLine($"Длина окружности: {Math.Round(2.0 * Math.PI * r, accuracyCalculation, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь окружности: {Math.Round(Math.PI * r * r, accuracyCalculation, MidpointRounding.AwayFromZero)}");
					break;
				case Figure.Triangle:
					Console.WriteLine("Выбран равносторонний треугольник:");
					double a = ReadDouble("длину стороны:", accuracyCalculation);
					Console.WriteLine($"Периметр треугольника: {Math.Round(3.0*a, accuracyCalculation, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь треугольника: {Math.Round(a*a*Math.Sqrt(3)/4, accuracyCalculation, MidpointRounding.AwayFromZero)}");
					break;
				case Figure.Rectangle:
					Console.WriteLine("Выбран прямоугольник:");
					double b1 = ReadDouble("длину 1-й стороны:", accuracyCalculation);
					double b2 = ReadDouble("длину 2-й стороны:", accuracyCalculation);
					Console.WriteLine($"Периметр прямоугольника: {Math.Round(2.0*(b1+b2), accuracyCalculation, MidpointRounding.AwayFromZero)}");
					Console.WriteLine($"Площадь прямоугольника: {Math.Round(b1*b2, accuracyCalculation, MidpointRounding.AwayFromZero)}");
					break;
			}
		}

		// Метод для ввода вида фигуры (enum)
		static Figure ReadEnum(string name)										
		{
			for ( ; ; )
			{
				try
				{
					// Проверка на ввод в рамках [1..3] - Figure
					Figure fig;
					bool figReadResult;
					do
					{
						Console.Write($"Введите {name}");
						fig = (Figure)Enum.Parse(typeof(Figure), Console.ReadLine());
						figReadResult = ( (int)fig<1 ) || ( (int)fig>3 );
						if (figReadResult) WriteWithColor("Введенное значение выходит за пределы допустимых.", ConsoleColor.Red);
					}
					while (figReadResult);                     //(!((int)fig >= 1 && (int)fig <= 3));	
					return fig;
				}
				catch (ArgumentOutOfRangeException exception)   //Console.ReadLine()
				{
					WriteWithColor("Слишком большое количество символов\n" + exception.Message, ConsoleColor.Red);
				}
				catch (Exception exception) when (exception is ArgumentNullException || exception is ArgumentException)     //Enum.Parse()
				{
					WriteWithColor("Не удаётся распознать число. Пожалуйста, попробуйте еще раз.\n" + exception.Message, ConsoleColor.Red);
				}
				catch (OverflowException exception)             //Enum.Parse()
				{
					WriteWithColor("Введенное значение выходит за пределы допустимых. Пожалуйста, попробуйте еще раз.\n" + exception.Message, ConsoleColor.Red);
				}
			}
		}

		// Метод для ввода значения double с указанием кол-ва знаков после запятой и проверкой значений
		static double ReadDouble(string name, int accuracy)
		{
			for ( ; ; )
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

		// Метод для вывода цветного сообщения
		static void WriteWithColor(string message, ConsoleColor color)
		{
			var restoreColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ForegroundColor = restoreColor;
		}

	}
}

//default:        // немного поигрался с выбросом и отловом собственного исключения. НО ЭТОТ КОД НЕ НУЖЕН И НЕКОРРЕКТЕН!!!
//	try
//	{
//		throw new Exception("Не удалось выбрать фигуру. Пожалуйста перезапустите программу для корректного выбора фигуры.");
//	}
//	catch (Exception exception)
//	{
//		WriteWithColor(exception.Message, ConsoleColor.Red);
//	}
//	break;
