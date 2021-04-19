using System.IO;
using System.Net;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Services;
using Lessons10_REST_API.Steps;
using RestSharp;
using Xunit;

namespace Lessons10_REST_API.Tests.TestSuiteTests
{
    public class AddSuiteTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private string _projectId;

        public AddSuiteTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Create test suite")]
        [AllureSubSuite("Create test suite With Correct Values unauthorized")]
        [AllureXunit]
        public void CreateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuite();

            var endPoint = Path.Combine(Configurator.AddSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.Admin, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(requestModel, content);
        }

        [AllureTag("Create test suite")]
        [AllureSubSuite("Create test suite with missing value")]
        [AllureXunit]
        public void CreateTestSuite_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuiteWithMissingRequiredValues();

            var endPoint = Path.Combine(Configurator.AddSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.Admin, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }

        [AllureTag("Create test suite")]
        [AllureSubSuite("Create test suite When Unauthorized")]
        [AllureXunit]
        public void CreateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuite();

            var endPoint = Path.Combine(Configurator.AddSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.UnAuthorisedClient, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }

        [AllureTag("Create test suite")]
        [AllureSubSuite("Create test suite Without Admin status")]
        [AllureXunit]
        public void CreateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuite();

            var endPoint = Path.Combine(Configurator.AddSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.User, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.Forbidden, response.Result.StatusCode);
        }
    }
}