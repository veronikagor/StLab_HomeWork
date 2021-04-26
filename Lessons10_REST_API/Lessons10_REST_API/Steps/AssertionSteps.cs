using System.Net;
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
            projectResponse.Name.Should().BeEquivalentTo(projectRequest.Name);
            projectResponse.Announcement.Should().BeEquivalentTo(projectRequest.Announcement);
            projectResponse.ShowAnnouncement.Should().Be(projectRequest.ShowAnnouncement);
            projectResponse.SuiteMode.Should().BeInRange(1, 3);
            projectResponse.Url.Should().NotBe(null);
        }

        public static void TheTestSuiteModelShouldMatchTheFollowingValues(TestSuiteResponseModel testSuiteResponse, TestSuiteRequestModel testSuiteRequest)
        {
            testSuiteResponse.Description.Should().Be(testSuiteRequest.Description);
            testSuiteResponse.Name.Should().Be(testSuiteRequest.Name);
        }
        
    }
}