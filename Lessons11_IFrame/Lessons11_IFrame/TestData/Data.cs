using System.Collections.Generic;
using NUnit.Framework;

namespace Lessons11_IFrame.TestData
{
    public static class Data
    {
        public static IEnumerable<TestCaseData> DesiredProduct
        {
            get
            {
                yield return new TestCaseData("Электрочайник");
                yield return new TestCaseData("Тостер");
            }
        }
    }
}