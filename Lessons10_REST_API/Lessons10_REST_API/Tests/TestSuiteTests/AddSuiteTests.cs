using System.Net;
using System.Threading.Tasks;
using Allure.Commons;
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

        [AllureEpic("Test suite actions")]
        [AllureFeature("Add test suite")]
        [AllureStory("Add test suite with correct values")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Positive case")]
        [AllureXunit]
        public async Task CreateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, suite);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Add test suite")]
        [AllureStory("Add test suite with incorrect values")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateTestSuite_WhenMissingRequiredValues_ShouldReturnBadRequest()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Add test suite")]
        [AllureStory("Add test suite with incorrect format project Id")]
        [AllureTag("Negative case")]
        [AllureXunitTheory]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task CreateTestSuite_WithIncorrectFormatId_ShouldReturnBadRequest(object id)
        {
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(id, suite, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Add test suite")]
        [AllureStory("Add test suite when user is unauthorized")]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Add test suite")]
        [AllureStory("Add test suite when user is without admin status")]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var suite = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.AddTestSuite(projectId, suite, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}