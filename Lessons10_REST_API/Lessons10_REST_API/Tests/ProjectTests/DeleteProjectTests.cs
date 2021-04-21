using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.DataProvider;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    public class DeleteProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;

        public DeleteProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }
        
        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project with valid project Id")]
        public async Task DeleteProject_WithExistentProjectId_ShouldReturnOk()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(project.Data.Id.ToString(), _fixture.Admin);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project with incorrect format project Id")]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public async Task DeleteProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.DeleteProject(id.ToString(), _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project when user is unauthorized")]
        public async Task DeleteProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId: project.Data.Id.ToString(),
                client: _fixture.UnAuthorisedClient);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project when user is without admin status")]
        public async Task DeleteProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(project.Data.Id.ToString(), _fixture.User);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}