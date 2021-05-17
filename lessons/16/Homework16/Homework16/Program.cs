using System;

namespace Homework16
{
    class Program
    {
        static void Main(string[] args)
        {
            // Домашка/самостоялка
            // 1. касаемо окружности
            var circleRadius = 2;
            var circle = new Calculator.Figure.Circle(circleRadius);
            var circlePerimeter = circle.Calculate(Calculator.Operation.CircleOperations.Perimeter);
            var circleSquare = circle.Calculate(Calculator.Operation.CircleOperations.Square);

            Console.WriteLine(
                $"For the circle with radius {circleRadius}\n" +
                $"\tPerimeter is\t{circlePerimeter}\n" +
                $"\tSquare is\t{circleSquare}");


            // 2. касаемо квдрата
            var squareSide = 4;
            var square = new Calculator.Figure.Square(squareSide);
            var squarePerimeter = square.Calculate(Calculator.Operation.SquareOperations.Perimeter);
            var squareSquare = square.Calculate(Calculator.Operation.SquareOperations.Square);

            Console.WriteLine(
                $"For the square with side {squareSide}\n" +
                $"\tPerimeter is\t{squarePerimeter}\n" +
                $"\tSquare is\t{squareSquare}");


        }
    }
}
