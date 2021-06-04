using System;
using System.IO;

namespace HomeWork17
{
    class FileWriterWithProgress
    {
        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
            // количество знаков после запятой = на 1 больше кол-ва знаков у переменной percentageToFireEvent (для точности)
            var kolvoZnakov = (percentageToFireEvent - (int)percentageToFireEvent).ToString().Length - 2+1;     // -2, потому надо убрать из длины 0 и точку, +1 чтоб добавить точности
            Console.WriteLine($"кол-во знаков {kolvoZnakov}");

            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");

            double actualPersent;                   // вынес за цикл, чтоб не создавать при каждой итерации
            for (int i=0, k=1; i<data.Length; i++)
            {
                actualPersent = Math.Round((float)i / data.Length, kolvoZnakov, MidpointRounding.AwayFromZero);
                File.AppendAllText($"logs\\{fileName}", data[i].ToString());

                Console.WriteLine($"i={i}; actualPersent = {actualPersent}; percentageToFireEvent*k = {percentageToFireEvent*k}");
                if (actualPersent >= percentageToFireEvent*k)
                {
                    Performed?.Invoke(this, new InfoDownload(percentageToFireEvent));
                    k++;    // k-1 = количество событий Performed
                }
                if (i == data.Length - 1) Completed?.Invoke();        // вызов WritingCompleted
            }
        }

        // ниже 2 типа события
        // 1. Performed достигнут прогресс записи, кратный кратный параметру percentageToFireEvent
        // и событие и делегат записаны в 1 строку - !!!СПОСОБ С ПЕРЕДАЧЕЙ ДАННЫХ В АРГУМЕНТЕ СОБСТВЕННОГО ТИПА InfoDownload!!!
        public event EventHandler<InfoDownload> Performed;

        // 2. Completed достигнут конец записи - способ использования объявленных делегатов для событий
        public Action WritingCompleted;     // делеаг для события
        public event Action Completed;      // событие, в котором будет использоваться делегат выше
    }

    // класс, для передачи данных о событии   !!!ОБЯЗАТЕЛЬНО УКАЗАТЬ, ЧТО НАСЛЕДУЕТСЯ ОТ EventArgs!!!
    class InfoDownload : EventArgs
    {
        public float Zagruzka { get;}
        public InfoDownload(float zagruzka)
        {
            Zagruzka = zagruzka;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Byte[] ArrayForFile = new Byte[15];
            rnd.NextBytes(ArrayForFile);

            var writer = new FileWriterWithProgress();

            writer.Performed += StWritingPerformed; // подписались на событие "процесса загрузки" обработчиком, СООТВЕТСТВУЮЩИМ СИГНАТУРЕ ДЕЛЕГАТА EventHandler<InfoDownload>

            writer.WritingCompleted = () => Console.WriteLine("Достигнут конец записи.");
            writer.Completed += writer.WritingCompleted;

            writer.WriteBytes("log.txt", ArrayForFile, 0.1f);
        }

        // обработчик с нужной сигнатурой для EventHandler<InfoDownload> // !!!ОБЯЗАТЕЛЬНО УКАЗАТЬ СОБСТВЕННЫЙ ТИП АРГУМЕНТА InfoDownload!!!
        private static void StWritingPerformed(object sender, InfoDownload persent) =>
            Console.WriteLine($"Достигнут прогресс записи = {persent.Zagruzka};");

    }
}


// Math.Round(chislo, kolvoZnakov, MidpointRounding.AwayFromZero) - округление обычное математическое, а не банковское