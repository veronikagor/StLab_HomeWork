using FluentAssertions;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Models.TestSuiteModels;

namespace Lessons10_REST_API.Steps
{
    public static class AssertionSteps
    {
        public static void TheProjectModelShouldMatchTheFollowingValues(ProjectResponseModel projectResponse,
            ProjectRequestModel projectRequest)
        {
            projectResponse.Id.Should().NotBe(null);
            projectResponse.Name.Should().Be(projectRequest.Name);
            projectResponse.Announcement.Should().Be(projectRequest.Announcement);
            projectResponse.ShowAnnouncement.Should().Be(projectRequest.ShowAnnouncement);
            projectResponse.SuiteMode.Should().BeInRange(1, 3);
            projectResponse.Url.Should().NotBe(null);
        }

        public static void TheTestSuiteModelShouldMatchTheFollowingValues(TestSuiteResponseModel testSuiteResponseModel, TestSuiteRequestModel testSuiteRequestModel)
        {
            testSuiteResponseModel.Description.Should().Be(testSuiteRequestModel.Description);
            testSuiteResponseModel.Name.Should().Be(testSuiteRequestModel.Name);
        }
    }
}