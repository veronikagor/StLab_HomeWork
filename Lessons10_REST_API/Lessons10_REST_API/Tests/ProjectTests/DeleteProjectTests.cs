using System.Net;
using System.Threading.Tasks;
using Allure.Commons;
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
        
       // [AllureSubSuite("Delete project")]
        [AllureEpic("Project actions")]
        [AllureFeature("Delete project")]
        [AllureStory("Delete project with valid project Id")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Positive case")]
        [AllureXunit]
        public async Task DeleteProject_WithExistentProjectId_ShouldReturnOk()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
       // [AllureSubSuite("Delete project")]
        [AllureEpic("Project actions")]
        [AllureFeature("Delete project")]
        [AllureStory("Delete project with nonexistent project Id")]
        [AllureOwner("MyOwner")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task DeleteProject_WithNonexistentProjectId_ShouldReturnBadRequest()
        {
            var projectsId = await GettingProjectsStep.GetProjectsId();
            var nonexistentProjectId = RandomUtils.GetNonExistentProjectId(projectsId);
            var response = await RequestProcessor.DeleteProject(nonexistentProjectId, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        //[AllureSubSuite("Delete project")]
        [AllureEpic("Project actions")]
        [AllureFeature("Delete project")]
        [AllureStory("Delete project with incorrect format project Id")]
        [AllureOwner("MyOwner")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunitTheory]
        [MemberData(nameof(RandomUtils.GetInvalidProjectId), MemberType = typeof(RandomUtils))]
        public async Task DeleteProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var response = await RequestProcessor.DeleteProject(id, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        //[AllureSubSuite("Delete project")]
        [AllureEpic("Project actions")]
        [AllureFeature("Delete project")]
        [AllureStory("Delete project when user is unauthorized")]
        [AllureOwner("MyOwner")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task DeleteProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        //[AllureSubSuite("Delete project")]
        [AllureEpic("Project actions")]
        [AllureFeature("Delete project")]
        [AllureStory("Delete project when user is without admin status")]
        [AllureOwner("MyOwner")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task DeleteProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(_fixture.Admin);
            var response = await RequestProcessor.DeleteProject(projectId, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}