using System;
using System.IO;

namespace HomeWork17
{
    class FileWriterWithProgress
    {
        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
            // fileName - имя файла - создать, если не создать
            // data - массив типа byte для записи
            // percentageToFireEvent - это процентная величина для вызова периодического события о прогрессе (0 < percentageToFireEvent < 1)

            // количество знаков после запятой = на 1 больше кол-ва знаков у переменной percentageToFireEvent (для точности)
            var kolvoZnakov = (percentageToFireEvent - (int)percentageToFireEvent).ToString().Length - 2+1;     // -2, потому надо убрать из длины 0 и точку, +1 чтоб добавить точности
            Console.WriteLine($"колво знаков {kolvoZnakov}");

            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");

            for (int i=0, k=1; i<data.Length; i++)
            {
                File.AppendAllText($"logs\\{fileName}", data[i].ToString());

                Console.WriteLine($"i={i}");
                Console.WriteLine($"i/data.Length = {Math.Round((float)i / data.Length, kolvoZnakov, MidpointRounding.AwayFromZero)}; percentageToFireEvent*k = {percentageToFireEvent*k}");

                if (Math.Round((float)i / data.Length, kolvoZnakov, MidpointRounding.AwayFromZero) >= percentageToFireEvent*k)
                {
                    Performed?.Invoke(percentageToFireEvent);   // вызов WritingPerformed
                    k++;                                        // k-1 = количество событий Performed
                }
                if (i == data.Length - 1) Completed?.Invoke();        // вызов WritingCompleted
            }
        }

        // ниже 2 типа события
        // WritingPerformed достигнут прогресс записи, кратный кратный параметру percentageToFireEvent
        public Action<float> WritingPerformed;
        public event Action<float> Performed;

        // WritingCompleted достигнут конец записи.
        public Action WritingCompleted;
        public event Action Completed;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Byte[] ArrayForFile = new Byte[15];
            rnd.NextBytes(ArrayForFile);

            var writer = new FileWriterWithProgress();

            writer.WritingPerformed = (persent) => { Console.WriteLine($"Достигнут прогресс записи = {persent*100}%;"); };
            writer.Performed += writer.WritingPerformed;

            writer.WritingCompleted = () => Console.WriteLine("Достигнут конец записи.");
            writer.Completed += writer.WritingCompleted;

            writer.WriteBytes("log.txt", ArrayForFile, 0.1f);
        }
    }
}



// Math.Round(chislo, kolvoZnakov, MidpointRounding.AwayFromZero)