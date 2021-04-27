using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Lessons10_REST_API.Base;
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

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite with correct value")]
        public async Task UpdateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            var suite = await CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.UpdateTestSuite(suite.Data.Id, testSuiteToUpdate, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, testSuiteToUpdate);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite with incorrect value")]
        public async Task UpdateTestSuite_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues();

            var response = await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite when user is unauthorized")]
        public async Task UpdateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response =
                await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite when user is without admin status")]
        public async Task UpdateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var suite = await CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();

            var response = await RequestProcessor.UpdateTestSuite(suite.Data.Id, testSuiteToUpdate, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}