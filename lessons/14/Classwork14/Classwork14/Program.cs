using System;
using System.Collections;
using System.Collections.Generic;

namespace Classwork14
{
    class ErrorList:IDisposable, IEnumerable<string>
    {
        public string Category { get;}
        private List<string> Errors { get; set; }
        public ErrorList(string category, string error)
        {
            Category = category;
            Errors = new List<string>();
            Errors.Add(error);
        }
        public void Dispose()
        {
            Errors.Clear();
            Errors = null;
            //throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Errors.GetEnumerator();
            // throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }   // обратная связь (для использования старого)
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var er1 = new ErrorList("dfv", "ewrf");
            er1.Errors.Add("dvqdcqdc");
            er1.Errors.Add("dfsfsff");

            foreach (var item in er1.Errors)
            {
                Console.WriteLine($"Категория: {item}");
            }

        }
    }
}
