using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.DataProvider;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    [Collection("TestRail collection")]
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

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [AllureTag("Get project")]
        [AllureXunitTheory(DisplayName = "Get project with incorrect format Id")]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public async Task GetProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.GetProject(id.ToString(), _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project when user is unauthorized")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.GetProject(project.Data.Id.ToString(), _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project user is without admin status")]
        public async Task GetProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var project = await CreatingProjectStep.GetTestProject(_fixture.Admin);
            var response = await RequestProcessor.GetProject(project.Data.Id.ToString(), _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}