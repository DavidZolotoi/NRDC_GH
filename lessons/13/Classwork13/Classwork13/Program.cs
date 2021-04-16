using System;

namespace Classwork13
{
    abstract class FlyMachine
    {
        public int MaxHeight { get; private set; }
        public int CurrentHeight { get; private set; }
        public FlyMachine(int maxHeight)
        {
            MaxHeight = maxHeight;
            CurrentHeight = 0;
        }
        public void TakeUpper(int delta)
        {
            if (delta <= 0) throw new ArgumentOutOfRangeException();
            if (CurrentHeight + delta > MaxHeight) delta = MaxHeight - CurrentHeight;
            CurrentHeight += delta;
        }
        public void TakeLower(int delta)
        {
            if (delta <= 0) throw new ArgumentOutOfRangeException();
            if (CurrentHeight - delta < 0) throw new InvalidOperationException("Crash");
            CurrentHeight -= delta;
        }
        public virtual void WriteInfo(string info)
        {
            string infoTotal =
                $"MaxHeight:\t{MaxHeight}\n" +
                $"CurrentHeight:\t{CurrentHeight}\n";
            Console.WriteLine(infoTotal + info);
        }
    }

    class Helicopter:FlyMachine
    {
        public byte BladesCount { get; private set; }
        public Helicopter(int maxHeight, byte bladesCount):base(maxHeight)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It's a helicopter, welcome aboard!");
        }
        public void infoFly()
        {
            string info = $"BladesCount:\t{BladesCount}\n";
            base.WriteInfo(info);
        }
    }

    class Plane : FlyMachine
    {
        public byte EnginesCount { get; private set; }
        public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
        {
            EnginesCount = enginesCount;
            Console.WriteLine("It's a plane, welcome aboard!");
        }
        public void infoFly()
        {
            string info = $"EnginesCount:\t{EnginesCount}\n";
            base.WriteInfo(info);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var plane = new Plane(100, 4);
            plane.TakeUpper(120);
            plane.TakeLower(100);
            plane.infoFly();
            //plane.WriteAllProperties2();

            var helicopter = new Helicopter(80, 3);
            helicopter.TakeUpper(120);
            helicopter.TakeLower(60);
            helicopter.infoFly();
            //helicopter.WriteAllProperties2();

        }
    }
}
