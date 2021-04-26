using Bogus;
using Lessons10_REST_API.Constants;
using Lessons10_REST_API.Models.TestSuiteModels;

namespace Lessons10_REST_API.Factories
{
    public static class TestSuiteFactory
    {
        public static TestSuiteRequestModel GetTestSuite()
        {
            return new Faker<TestSuiteRequestModel>("en")
                .RuleFor(p => p.Name, f => f.Lorem.Word())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(TestsuiteConstants.MaxTestSuiteDescriptionWordCount));
        }
        
        public static TestSuiteRequestModel GetTestSuiteWithMissingRequiredValues()
        {
            return new Faker<TestSuiteRequestModel>("en")
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(TestsuiteConstants.MaxTestSuiteDescriptionWordCount));
        }
    }
}