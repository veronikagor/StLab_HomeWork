using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;

namespace Lessons10_REST_API.Tests.TestSuiteTests
{
    public class UpdateTestSuite : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private string _projectId;

        public UpdateTestSuite(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite with correct value")]
        public async Task UpdateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();
            var response = await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.Admin);
            var content = GettingContentHelper.GetTestSuiteResponseContent(response);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(content, testSuiteToUpdate);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite with with incorrect value")]
        public async Task UpdateTestSuite_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuiteWithMissingRequiredValues(); 
            var response = await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite when  user is unauthorized")]
        public async Task UpdateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite(); 
            var response = await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.UnAuthorisedClient);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [AllureTag("Update test suite")]
        [AllureXunit(DisplayName = "Update test suite when user is without admin status")]
        public async Task UpdateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var suite = CreatingTestSuiteStep.GetTestSuite(_fixture.Admin);
            var testSuiteToUpdate = TestSuiteFactory.GetTestSuite();
            var response = await RequestProcessor.UpdateTestSuite(suite.Id, testSuiteToUpdate, _fixture.User);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}