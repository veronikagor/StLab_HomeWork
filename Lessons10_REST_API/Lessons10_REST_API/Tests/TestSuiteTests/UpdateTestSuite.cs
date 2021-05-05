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

namespace Lessons10_REST_API.Tests.TestSuiteTests
{
    [Collection("TestRail collection")]
    public class UpdateTestSuite : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;

        public UpdateTestSuite(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Update test suite")]
        [AllureStory("Update test suite with correct value")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Positive case")]
        [AllureXunit]
        public async Task UpdateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            var suite = await CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.UpdateTestSuite(suite.Data.Id, testSuiteToUpdate, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, testSuiteToUpdate);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Update test suite")]
        [AllureStory("Update test suite with incorrect suite Id")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunitTheory]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task UpdateTestSuite_WithIncorrectSuiteId_ShouldReturnBadRequest(object suiteId)
        {
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.UpdateTestSuite(suiteId, testSuiteToUpdate, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Update test suite")]
        [AllureStory("Update test suite when user is unauthorized")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task UpdateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response =
                await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureEpic("Test suite actions")]
        [AllureFeature("Update test suite")]
        [AllureStory("Update test suite when user is without admin status")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task UpdateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var suite = await CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.UpdateTestSuite(suite.Data.Id, testSuiteToUpdate, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}