using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calc;

        [SetUp]
        public void SetUp()
        {
            _calc = new Calculator();
            TestContext.WriteLine("Setup: Calculator instance created.");
        }

        [TearDown]
        public void TearDown()
        {
            _calc = null;
            TestContext.WriteLine("TearDown: Calculator instance destroyed.");
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = _calc.Add(10, 5);
            Assert.That(result, Is.EqualTo(15));
        }

        [TestCase(5, 5, 10)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, 5, 0)]
        [TestCase(-3, -2, -5)]
        public void Add_MultipleCases_ShouldReturnExpectedResult(int a, int b, int expected)
        {
            int result = _calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Ignore("Divide test is skipped temporarily.")]
        public void Divide_ByZero_ShouldReturnZero()
        {
            int result = _calc.Divide(10, 0);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
