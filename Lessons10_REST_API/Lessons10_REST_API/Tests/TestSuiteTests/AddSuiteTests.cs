using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.DataProvider;
using Lessons10_REST_API.Factories;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;
using Xunit.Abstractions;

namespace Lessons10_REST_API.Tests.TestSuiteTests
{
    [Collection("TestRail collection")]
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
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, suite);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite with incorrect values")]
        public async Task CreateTestSuite_WithInCorrectValues_ShouldReturnBadRequest()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Add test suite")]
        [AllureXunitTheory(DisplayName = "Add test suite with incorrect format project Id")]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task CreateTestSuite_WithIncorrectFormatId_ShouldReturnBadRequest(object id)
        {
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(id, suite, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite when user is unauthorized")]
        public async Task CreateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureTag("Add test suite")]
        [AllureXunit(DisplayName = "Add test suite when user is without admin status")]
        public async Task CreateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}