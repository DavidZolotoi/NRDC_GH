using System;

namespace Classwork13
{
    abstract class FlyMachine
    {
        public int MaxHeight { get; private set; }
        public int CurrentHeight { get; private set; }
        public virtual string InfoTotal =>
                $"MaxHeight:\t{MaxHeight}\n" +
                $"CurrentHeight:\t{CurrentHeight}\n";
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

        public abstract void WriteInfo();

        public virtual void WriteInfo2()
        {
            Console.WriteLine(InfoTotal);
        }

    }

    class Helicopter:FlyMachine
    {
        public byte BladesCount { get; private set; }
        public override string InfoTotal =>
                                base.InfoTotal +
                                $"BladesCount:\t{BladesCount}\n";
        public Helicopter(int maxHeight, byte bladesCount):base(maxHeight)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It's a helicopter, welcome aboard!");
        }
        public override void WriteInfo()
        {
            Console.WriteLine("О вертолете:\n" + InfoTotal);
        }
        public override void WriteInfo2()
        {
            Console.WriteLine("О вертолете через другой метод:");
            base.WriteInfo2();
        }
        
    }

    class Plane : FlyMachine
    {
        public byte EnginesCount { get; private set; }
        public override string InfoTotal =>
                        base.InfoTotal +
                        $"EnginesCount:\t{EnginesCount}\n";

        public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
        {
            EnginesCount = enginesCount;
            Console.WriteLine("It's a plane, welcome aboard!");
        }
        public override void WriteInfo()
        {
            Console.WriteLine("О самолете:\n" + InfoTotal);
        }
        public override void WriteInfo2()
        {
            Console.WriteLine("О самолете через другой метод:");
            base.WriteInfo2();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var plane = new Plane(100, 4);
            plane.TakeUpper(120);
            plane.TakeLower(100);
            plane.WriteInfo();
            plane.WriteInfo2();

            var helicopter = new Helicopter(80, 3);
            helicopter.TakeUpper(120);
            helicopter.TakeLower(60);
            helicopter.WriteInfo();
            helicopter.WriteInfo2();

        }
    }
}
