namespace Homework10
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AgePlus { get => Age + 4; }
        public string Info { get => $"Name: {Name}, age in 4 years: {AgePlus}."; }
    }
}
