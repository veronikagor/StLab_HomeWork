using System;
using System.Collections.Generic;
using Lessons5_NUnit.Models;
using NUnit.Framework;

namespace Lessons5_NUnit.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private Calcucator _calculator;

        private static object[] _cases =
        {
            new object[] {14, 4, 2},
            new object[] {20, 3, 1}
        };

        private static IEnumerable<TestCaseData> TestDataToCalculation
        {
            get
            {
                yield return new TestCaseData(-100, 100, 0);
                yield return new TestCaseData(-100, -200, -300);
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _calculator = new Calcucator();
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup runs before each test method.");
        }

        [TestCaseSource(nameof(TestDataToCalculation))]
        [Category("ConditionAsserts")]
        [Category("IdentityAsserts")]
        public void TestContains(int a, int b, int expectedResult)
        {
            int[] array =
            {
                _calculator.Sum(a, b),
                _calculator.Division(a, b),
                _calculator.Multiplication(a, b)
            };
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(array);
                Assert.Contains(0, array);
                Assert.IsNotNull(array);
            });
        }

        [TestCaseSource(nameof(_cases))]
        [Category("ComparisonsAsserts")]
        public void TestRemainderOfDivision(int a, int b, int expectedCount)
        {
            Assert.LessOrEqual(expectedCount, _calculator.RemainderOfDivision(a, b));
        }

        [Test]
        [Category("ConditionAsserts")]
        public void TestNegativeNumbers([Random(1, 5, 3)] int randomValue)
        {
            Assert.False(double.IsNegative(_calculator.Division(randomValue, 1)));
        }

        [TestCaseSource(nameof(_cases))]
        [Category("ComparisonsAsserts")]
        public void TestReminder(int a, int b, int expectedResult)
        {
            Assert.Less(_calculator.RemainderOfDivision(a, b), b);
        }

        [Test]
        [Category("EqualityAsserts")]
        [Ignore("Ignore a fixture")]
        public void TestSum()
        {
            Assert.AreNotEqual(0, _calculator.Sum(2, 3));
        }

        [Test]
        [Category("IdentityAsserts")]
        public void TestMultiplication()
        {
            var result = "6";
            Assert.AreSame(result, _calculator.Multiplication(2, 3).ToString());
        }

        [Test]
        [Category("ExceptionAsserts")]
        [Property("Priority", "High")]
        public void TestDivisionByZero()
        {
            Assert.Throws<DivideByZeroException>(
                delegate { new Calcucator().Division(8, 0); });
        }

        [Test]
        [Category("ConditionAsserts")]
        public void TestDivisionInfinity()
        {
            Assert.Multiple(() =>
            {
                Assert.True(double.IsPositiveInfinity(_calculator.Division(3d, 0d)));
                Assert.True(double.IsNegativeInfinity(_calculator.Division(-3d, 0d)));
            });
        }

        [Test]
        [Category("ConditionAsserts")]
        public void TestDivisionNaN()
        {
            Assert.IsNaN(_calculator.Division(0d, 0d));
        }

        [Test]
        [Category("EqualityAsserts")]
        public void TestDivisionAndMultiplication()
        {
            Assert.Multiple(() =>
            {
                var a = TestContext.CurrentContext.Random.NextDouble(100);
                var b = TestContext.CurrentContext.Random.NextDouble(10, 20);
                Assert.Greater(a * b, _calculator.Division(a, b));
            });
        }

        [TestCase(1, 1, 2)]
        [TestCase(-1250, 10000, 8750)]
        [Category("EqualityAsserts")]
        public void TestSum(int a, int b, int expectedResult)
        {
            Assert.AreEqual(expectedResult, _calculator.Sum(a, b));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown runs after each test method.");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("OneTimeTearDown runs after executing all the tests in a fixture.");
        }
    }
}