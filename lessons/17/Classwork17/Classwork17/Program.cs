using System;

namespace Classwork17
{
    public delegate void RandomDataGeneratedHandler(int bytesDone, int bytesDoneToRaiseEvent);

    class RandomDataGenerator
    {
        public event RandomDataGeneratedHandler RandomDataGenerating;
        public event EventHandler RandomDataGenerated = default;
        public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
        {
            var mass = new byte[dataSize];
            int k = 0;
            for (int i = 0; i < dataSize; i++)
            {
                Random rand = new Random();
                mass[i] = (byte)rand.Next(-128, 127);
                if (i == k)
                {
                    k = k + bytesDoneToRaiseEvent;
                    RandomDataGenerating?.Invoke(i, dataSize);
                }
            }
            RandomDataGenerated?.Invoke(this, new EventArgs());
            return mass;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // public delegate void RandomDataGeneratedHandler(int bytesDone, int bytesDoneToRaiseEvent)
            var rdg = new RandomDataGenerator();
            rdg.RandomDataGenerating += (a, b) => Console.WriteLine($"Generated {a} from {b} bytes");


        }
    }
}
