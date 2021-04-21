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
    public class GetProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private int _projectId;

        public GetProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project with valid Id")]
        public async Task GetProject_WithExistentProjectId_ShouldReturnOk()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.GetProject(project.Data.Id.ToString(), _fixture.Admin);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project with incorrect format Id")]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public async Task GetProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.GetProject(id.ToString(), _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project when user is unauthorized")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.GetProject(project.Data.Id.ToString(), _fixture.UnAuthorisedClient);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project user is without admin status")]
        public async Task GetProject_WithoutAdminStatus_ShouldReturnUnauthorized()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.GetProject(project.Data.Id.ToString(), _fixture.User);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}