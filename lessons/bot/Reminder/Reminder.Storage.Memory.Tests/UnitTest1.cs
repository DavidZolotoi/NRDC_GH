using NUnit.Framework;

namespace Reminder.Storage.Memory.Tests
{
    // FizzBuzz

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public string FizzBuzz(int number)
        {
            if (number % 3 == 0)       return "Fizz";
            else if (number % 5 == 0)  return "Buzz";
            else if (number % 15 == 0) return "FizzBuzz";
            else return number.ToString();
        }

    }
}