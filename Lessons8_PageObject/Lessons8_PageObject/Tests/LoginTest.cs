using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Steps;
using NUnit.Framework;

namespace Lessons8_PageObject.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            Assert.AreEqual(Driver.Title, "Swag Labs");
        }
    }
}