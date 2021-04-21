using System.Threading.Tasks;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Models.ProjectModels;
using RestSharp;

namespace Lessons10_REST_API.Steps
{
    public static class CreatingTestSuiteStep
    {
        public static async Task<IRestResponse<ProjectResponseModel>> GetTestSuite(RestClient client)
        {
            var project = await CreatingProjectStep.GetTestProject(client);
            var suite = TestSuiteFactory.GetTestSuite();
            var response = await RequestProcessor.AddTestSuite(project.Data.Id, suite, client);

            return response;
        }
    }
}