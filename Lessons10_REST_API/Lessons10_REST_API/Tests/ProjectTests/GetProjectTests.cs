using System.IO;
using System.Net;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Services;
using Lessons10_REST_API.Utils;
using RestSharp;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    public class GetProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private int _projectId;

        public GetProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Get project")]
        [AllureSubSuite("Get project with existent project Id")]
        [AllureXunit]
        public void GetProject_WithExistentProjectId_ShouldReturnOk()
        {
            _projectId = Precondition.GetProject().Id;

            var endPoint = Path.Combine(Configurator.GetProjectUrlEndPoint, _projectId.ToString());

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.GET);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }
        
        [AllureTag("Get project")]
        [AllureSubSuite("Get project with missing required values")]
        [AllureXunit] 
        public void GetProject_WhenMissingProjectId_ShouldReturnBadRequest()
        {
            var request =
                CreatingRequest.CreateProjectRequest(Configurator.GetProjectUrlEndPoint,
                    Method.GET); 
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }

        [AllureTag("Get project")]
        [AllureSubSuite("Get project with incorrect format Id")]
        [AllureXunitTheory]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public void GetProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var endPoint = Path.Combine(Configurator.GetProjectUrlEndPoint, id.ToString());

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.GET);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }

        [AllureTag("Get project")]
        [AllureSubSuite("Get project when user is unauthorized")]
        [AllureXunit]
        public void GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            _projectId = Precondition.GetProject().Id;
            var endPoint = Path.Combine(Configurator.GetProjectUrlEndPoint, _projectId.ToString());

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.GET);
            var response = GettingResponse.GetProjectResponse(_fixture.UnAuthorisedClient, request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }
    }
}