using System.Net;
using System.Threading.Tasks;
using Allure.Commons;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Factories;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    [Collection("TestRail collection")]
    public class AddProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;

        public AddProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }
        
        [AllureEpic("Project actions")]
        [AllureFeature("Add project")]
        [AllureStory("Add project with valid values")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Positive case")]
        [AllureXunit]
        public async Task CreateProject_WithCorrectValues_ShouldReturnOk()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.Admin);
            var content = GettingContentHelper.GetProjectResponseContent(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            AssertionSteps.TheProjectModelShouldMatchTheFollowingValues(content, requestModel);
        }

        [AllureEpic("Project actions")]
        [AllureFeature("Add project")]
        [AllureStory("Add project with missing required value")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateProject_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            var requestModel = ProjectFactory.GetProjectWithMissingRequiredValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.Admin);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [AllureEpic("Project actions")]
        [AllureFeature("Add project")]
        [AllureStory("Add project when user is unauthorized")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.UnAuthorisedClient);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [AllureEpic("Project actions")]
        [AllureFeature("Add project")]
        [AllureStory("Add project when user is without admin status")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Negative case")]
        [AllureXunit]
        public async Task CreateProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.User);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}