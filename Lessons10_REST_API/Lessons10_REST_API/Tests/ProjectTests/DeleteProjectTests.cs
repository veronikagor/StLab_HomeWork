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
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project with nonexistent project Id")]
        public async Task DeleteProject_WithNonexistentProjectId_ShouldReturnBadRequest()
        {
            var projectsId = await GettingProjectsStep.GetProjectsId();
            var nonexistentProjectId = RandomUtils.GetNonExistentProjectId(projectsId);
            var response = await RequestProcessor.DeleteProject(nonexistentProjectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Delete project")]
        [AllureXunitTheory(DisplayName = "Delete project with incorrect format project Id")]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task DeleteProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.DeleteProject(id, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project when user is unauthorized")]
        public async Task DeleteProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureTag("Delete project")]
        [AllureXunit(DisplayName = "Delete project when user is without admin status")]
        public async Task DeleteProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}