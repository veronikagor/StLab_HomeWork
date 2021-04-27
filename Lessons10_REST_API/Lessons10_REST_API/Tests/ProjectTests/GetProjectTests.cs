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

        public GetProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project with valid Id")]
        public async Task GetProject_WithExistentProjectId_ShouldReturnOk()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.GetProject(projectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project with nonexistent project Id")]
        public async Task GetProject_WithNonexistentProjectId_ShouldReturnBadRequest()
        {
            var projectsId = await GettingProjectsStep.GetProjectsId();
            var nonexistentProjectId = RandomUtils.GetNonExistentProjectId(projectsId);
            var response = await RequestProcessor.GetProject(nonexistentProjectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Get project")]
        [AllureXunitTheory(DisplayName = "Get project with incorrect format Id")]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task GetProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.GetProject(id, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project when user is unauthorized")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.GetProject(projectId, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureTag("Get project")]
        [AllureXunit(DisplayName = "Get project user is without admin status")]
        public async Task GetProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.GetProject(projectId, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}