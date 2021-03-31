using System.Collections;
using NUnit.Framework;

namespace Lessons5_NUnit.Tests
{
    [TestFixture]
    public class TestCaseTest
    {
        /// <summary>
        /// The method allows to get the factorial of number. 
        /// </summary>
        /// <param name="x">number to get factorial</param>
        /// <returns></returns>
        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }

            else
            {
                return x * Factorial(x - 1);
            }
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(3).Returns(6);
                yield return new TestCaseData(2).Returns(2);
                yield return new TestCaseData(5).Returns(120);
            }
        }
    }
}