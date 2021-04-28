using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
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

        [AllureTag("Add project")]
        [AllureXunit(DisplayName = "Add project")]
        public async Task CreateProject_WithCorrectValues_ShouldReturnOk()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.Admin);
            var content = GettingContentHelper.GetProjectResponseContent(response);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            AssertionSteps.TheProjectModelShouldMatchTheFollowingValues(content, requestModel);
        }

        [AllureTag("Add project")]
        [AllureXunit(DisplayName = "Add project with missing required value")]
        public async Task CreateProject_WithMissingRequiredValue_ShouldReturnBadRequest()
        {
            var requestModel = ProjectFactory.GetProjectWithMissingRequiredValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.Admin);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [AllureTag("Add project")]
        [AllureXunit(DisplayName = "Add project when user is unauthorized")]
        public async Task CreateProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.UnAuthorisedClient);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [AllureTag("Add project")]
        [AllureXunit(DisplayName = "Add project when user is without admin status")]
        public async Task CreateProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
            var requestModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(requestModel, _fixture.User);

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}