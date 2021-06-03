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
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");

            for (int i = 0; i < data.Length; i++)
            {
                File.AppendAllText($"logs\\{fileName}", data[i].ToString());

                if (i % data.Length == percentageToFireEvent) Console.WriteLine("вызов события");   // вызов WritingPerformed
            }

            // вызов WritingCompleted


            // ниже 2 типа события
            // WritingPerformed достигнут прогресс записи, кратный кратный параметру percentageToFireEvent
            // WritingCompleted достигнут конец записи.


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Byte[] ArrayForFile = new Byte[10];
            rnd.NextBytes(ArrayForFile);

            var writer = new FileWriterWithProgress();
            writer.WriteBytes("log.txt", ArrayForFile, 0.1f);
        }
    }
}
