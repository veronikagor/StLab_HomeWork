using Bogus;
using Lessons10_REST_API.Models;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Models.TestSuiteModels;

namespace Lessons10_REST_API.Factory
{
    public static class ProjectFactory
    {
        public static Client GetInvalidCredential()
        {
            return new Faker<Client>()
                .RuleFor(p => p.UserName, f => f.Internet.UserName())
                .RuleFor(p => p.Password, f => f.Internet.Password(21));
        }

        public static ProjectRequestModel GetProjectWithCorrectValues()
        {
            return new Faker<ProjectRequestModel>()
                .RuleFor(p => p.Name, f => f.Lorem.Sentence(1))
                .RuleFor(p => p.Announcement, f => f.Lorem.Sentence(3))
                .RuleFor(p => p.ShowAnnouncement, f => f.Random.Bool())
                .RuleFor(p => p.SuiteMode, f => f.Random.Int(1, 3));
        }

        public static ProjectRequestModel GetProjectWithMissingRequiredValues()
        {
            return new Faker<ProjectRequestModel>()
                .RuleFor(p => p.Announcement, f => f.Lorem.Sentence(3))
                .RuleFor(p => p.SuiteMode, f => f.Random.Int(1, 3));
        }

        public static TestSuiteRequestModel GetTestSuite()
        {
            return new Faker<TestSuiteRequestModel>()
                .RuleFor(p => p.Name, f => f.Lorem.Sentence(1))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(3));
        }

        public static TestSuiteRequestModel GetTestSuiteWithMissingRequiredValues()
        {
            return new Faker<TestSuiteRequestModel>()
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(3));
        }
    }
}