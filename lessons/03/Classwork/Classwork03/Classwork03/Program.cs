using System;

namespace Classwork03
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Работа с переменными dynamic
            dynamic din;
            din = "stroka";
            din = 77;
            Console.WriteLine(din*din);

            // 2. Работа с object
            object ob;
            ob = "stroka";
            Console.WriteLine(ob.ToString().Length);

            // 3. Работа с var
            var per1=1;
            var per2=2;
            var per3=3;

            // 4. Работа со строковыми массивами
            var stroki = new string[4];
            for (var i=0; i<stroki.Length; i++)
            {
                stroki[i]=Console.ReadLine();
            }

        }
    }
}
