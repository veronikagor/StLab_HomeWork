using Bogus;
using Lessons10_REST_API.Models.TestSuiteModels;

namespace Lessons10_REST_API.Factory
{
    public static class TestSuiteFactory
    {
        public static TestSuiteRequestModel GetTestSuite()
        {
            return new Faker<TestSuiteRequestModel>()
                .RuleFor(p => p.Name, f => f.Lorem.Word())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(3));
        }
        
        public static TestSuiteRequestModel GetTestSuiteWithMissingRequiredValues()
        {
            return new Faker<TestSuiteRequestModel>()
                .RuleFor(p => p.Description, f => f.Lorem.Sentence(3));
        }
    }
}