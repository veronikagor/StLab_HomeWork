using System.Net;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Services;
using Lessons10_REST_API.Steps;
using RestSharp;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    public class AddProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;

        public AddProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Create Project")]
        [AllureSubSuite("Create project with correct values")]
        [AllureXunit]
        public void CreateProject_WithCorrectValues_ShouldReturnOk()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var request =
                CreatingRequest.CreateProjectRequest(Configurator.AddProjectUrlEndPoint, requestModel, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);
            var content = GettingResponse.GetProjectResponseContent(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
            AssertionSteps.TheProjectModelShouldMatchTheFollowingValues(content, requestModel);
        }

        [AllureTag("Create Project")]
        [AllureSubSuite("Create project with missing required value")]
        [AllureXunit]
        public void CreateProject_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            var requestModel = ProjectFactory.GetProjectWithMissingRequiredValues();
            var request =
                CreatingRequest.CreateProjectRequest(Configurator.AddProjectUrlEndPoint, requestModel, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }

        [AllureTag("Create Project")]
        [AllureSubSuite("Create project when user is unauthorized")]
        [AllureXunit]
        public void CreateProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var request =
                CreatingRequest.CreateProjectRequest(Configurator.AddProjectUrlEndPoint, requestModel, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.UnAuthorisedClient, request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }

        [AllureTag("Create Project")]
        [AllureSubSuite("Create project without admin status")]
        [AllureXunit]
        public void CreateProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var request =
                CreatingRequest.CreateProjectRequest(Configurator.AddProjectUrlEndPoint, requestModel, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.User, request);

            Assert.Equal(HttpStatusCode.Forbidden, response.Result.StatusCode);
        }
    }
}