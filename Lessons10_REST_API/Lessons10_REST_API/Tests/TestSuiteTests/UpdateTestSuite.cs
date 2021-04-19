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
    public class UpdateTestSuite : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private string _projectId;

        public UpdateTestSuite(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Update test suite")]
        [AllureSubSuite("Update test suite with correct value")]
        [AllureXunit]
        public void UpdateTestSuite_WithCorrectValues_ShouldReturnOk()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var testSuite = ProjectFactory.GetTestSuite();

            var endPointToAdd = Path.Combine(Configurator.AddSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPointToAdd, testSuite, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.Admin, request);
            var suiteId = GettingResponse.GetTestSuiteResponseContent(response.Result).Id.ToString();

            var testSuiteToUpdate = ProjectFactory.GetTestSuite();
            var endPointToUpdate = Path.Combine(Configurator.UpdateSuiteUrlEndPoint, suiteId);
            var request2 = CreatingRequest.CreateTestSuiteRequest(endPointToUpdate, testSuiteToUpdate, Method.POST);
            var response2 = GettingResponse.GeTestSuiteResponse(_fixture.Admin, request2);
            var newSuiteContent = GettingResponse.GetTestSuiteResponseContent(response2.Result);

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            AssertionSteps.TheTestSuiteModelShouldMatchTheFollowingValues(testSuiteToUpdate, newSuiteContent);
        }

        [AllureTag("Update test suite")]
        [AllureSubSuite("Update test suite with missing value")]
        [AllureXunit]
        public void UpdateTestSuite_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuiteWithMissingRequiredValues();

            var endPoint = Path.Combine(Configurator.UpdateSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.Admin, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }

        [AllureTag("Update test suite")]
        [AllureSubSuite("Update test suite when unauthorized")]
        [AllureXunit]
        public void UpdateTestSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuite();

            var endPoint = Path.Combine(Configurator.UpdateSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.UnAuthorisedClient, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }

        [AllureTag("Update test suite")]
        [AllureSubSuite("Update test suite without admin status")]
        [AllureXunit]
        public void UpdateTestSuite_WithoutAdminStatus_ShouldReturnForbidden()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            var requestModel = ProjectFactory.GetTestSuite();

            var endPoint = Path.Combine(Configurator.UpdateSuiteUrlEndPoint, _projectId);

            var request = CreatingRequest.CreateTestSuiteRequest(endPoint, requestModel, Method.POST);
            var response = GettingResponse.GeTestSuiteResponse(_fixture.User, request);
            var content = GettingResponse.GetTestSuiteResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.Forbidden, response.Result.StatusCode);
        }
    }
}