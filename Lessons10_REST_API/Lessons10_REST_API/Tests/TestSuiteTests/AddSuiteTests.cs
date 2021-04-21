using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.DataProvider;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;
using Xunit.Abstractions;

namespace Lessons10_REST_API.Tests.TestSuiteTests
{
    public class AddSuiteTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;

        public AddSuiteTests(TestRailFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite with correct values")]
        public async Task CreateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(project.Data.Id, suite, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, suite);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite with incorrect values")]
        public async Task CreateTestSuite_WithInCorrectValues_ShouldReturnOk()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(project.Data.Id, suite, _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite with incorrect format Id")]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public async Task CreateTestSuite_WithIncorrectFormatId_ShouldReturnBadRequest(object id)
        {
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(id, suite, _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite when user is unauthorized")]
        public async Task CreateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(project.Data.Id, suite, _fixture.UnAuthorisedClient);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite when user is without admin status")]
        public async Task CreateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(project.Data.Id, suite, _fixture.User);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}