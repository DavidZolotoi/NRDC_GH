using System;

namespace Classwork11
{
    partial class Pet2
    {
        public string Name { get; set; }
        public char Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Kind { get; set; }

        public Pet2(string name, char sex, DateTime dateOfBirth, string kind)
        {
            Name = name;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            Kind = kind;
        }  
    }
}
