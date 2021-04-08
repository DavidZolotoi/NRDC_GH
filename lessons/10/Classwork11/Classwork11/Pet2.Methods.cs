using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork11
{
    partial class Pet2
    {
        public string ShortDescription => $"Name {Name},\nAge {GetAge()}";
        public int GetAge() => (int)(DateTime.Now - DateOfBirth).TotalDays / 365;
        public void WriteInfo(bool showFullDescription = false) =>
           Console.WriteLine(
                            (showFullDescription)
                            ? $"Name {Name},\nSex {Sex},\nDateOfBirth {DateOfBirth},\nKind {Kind},\nAge {GetAge()}"
                            : ShortDescription
                            );
    }
}
