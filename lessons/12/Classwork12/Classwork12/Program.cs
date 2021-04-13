using System;

namespace Classwork12
{
    class BaseDocument
    {
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public virtual string Description => $"Title: {Title}\n Number: {Number}\n IssueDate: {IssueDate}";
        public BaseDocument(string title, string number, DateTimeOffset issueDate)
        {
            Title = title;
            Number = number;
            IssueDate = issueDate;
        }
        public void WriteToConsole()
        {
            Console.WriteLine(Description);
        }
    }

    class Passport : BaseDocument
    {
        public string Country { get; set; }
        public string PersonName { get; set; }
        public override string Description
            => $"{base.Description}\n Country: {Country}\n PersonName: {PersonName}";
        public Passport(string title, string number, DateTimeOffset issueDate, string country, string personName) :
            base(title, number, issueDate)
        {
            Country = country;
            PersonName = personName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var baseDocuments = new BaseDocument[]
            {
                new BaseDocument("baseDoc", "baseDoc№1", DateTimeOffset.UtcNow.AddYears(-5)),
                new Passport("Passport", "NumberPassport", DateTimeOffset.UtcNow.AddYears(-5), "Russian", "Vasya")
            };

            foreach (var person in baseDocuments)
            {
                if (person is Passport passport) passport.IssueDate = DateTimeOffset.Now;
                person.WriteToConsole();
            }
        }
    }
}
