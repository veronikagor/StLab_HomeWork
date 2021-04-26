using Bogus;
using Lessons10_REST_API.Constants;
using Lessons10_REST_API.Models.ProjectModels;

namespace Lessons10_REST_API.Factories
{
    public static class ProjectFactory
    {
        public static ProjectRequestModel GetProjectWithCorrectValues()
        {
            return new Faker<ProjectRequestModel>("en")
                .RuleFor(p => p.Name, f => f.Lorem.Word())
                .RuleFor(p => p.Announcement, f => f.Lorem.Sentence(ProjectConstants.MaxProjectAnnouncementWordCount))
                .RuleFor(p => p.ShowAnnouncement, f => f.Random.Bool())
                .RuleFor(p => p.SuiteMode, f => 3);
        }

        public static ProjectRequestModel GetProjectWithMissingRequiredValues()
        {
            return new Faker<ProjectRequestModel>("en")
                .RuleFor(p => p.Announcement, f => f.Lorem.Sentence(ProjectConstants.MaxProjectAnnouncementWordCount))
                .RuleFor(p => p.SuiteMode, f => f.Random.Int(ProjectConstants.MinProjectSuiteValue, ProjectConstants.MaxProjectSuiteValue));
        }
    }
}