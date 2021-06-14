using NUnit.Framework;

namespace Reminder.Storage.Memory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        // НИЖЕ 3 простых теста //
        // 1.
        [Test]
        public void Giv3GetFizz()
        {
            Assert.AreEqual("Fizz", FizzBuzz(3));
        }
        // 2.
        [Test]
        public void Giv5GetBuzz()
        {
            Assert.AreEqual("Buzz", FizzBuzz(5));
        }
        // 3.
        [Test]
        public void Giv15GetFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", FizzBuzz(15));
        }

        // НИЖЕ другой способ заменить верхние 3 на 1:
        //[TestCase]
        // не доделал

        public string FizzBuzz(int number)
        {
            switch (0 == number % 3, 0 == number % 5)
            {
                case (true, true):
                    return "FizzBuzz";
                case (true, false):
                    return "Fizz";
                case (false, true):
                    return "Buzz";
                default:
                    return number.ToString();
            }
        }
    }
}