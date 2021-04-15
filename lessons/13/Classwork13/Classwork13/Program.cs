using System;

namespace Classwork13
{
    abstract class FlyMachine
    {
        public int MaxHeight { get; private set; }
        public int CurrentHeight { get; private set; }
        public FlyMachine(int maxHeight, byte bladesCount)
        {
            MaxHeight = maxHeight;
        }
        protected void TakeUpper(int delta)
        {
            if (delta <= 0) throw new ArgumentOutOfRangeException();
            if (CurrentHeight + delta > MaxHeight) delta = MaxHeight - CurrentHeight;
            CurrentHeight += delta;
        }
        protected void TakeLower(int delta)
        {
            if (delta <= 0) throw new ArgumentOutOfRangeException();
            if (CurrentHeight - delta < 0) throw new InvalidOperationException("Crash");
            CurrentHeight -= delta;
        }
    }

    class Helicopter:FlyMachine
    {
        public byte BladesCount { get; private set; }
        public Helicopter(int maxHeight, byte bladesCount):base(maxHeight, bladesCount)
        {
            // НЕДОДЕЛАЛ
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
