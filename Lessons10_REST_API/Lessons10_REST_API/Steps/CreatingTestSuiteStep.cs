using System.Threading.Tasks;
using Lessons10_REST_API.Factories;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Models.ProjectModels;
using NLog;
using RestSharp;

namespace Lessons10_REST_API.Steps
{
    public static class CreatingTestSuiteStep
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static async Task<IRestResponse<ProjectResponseModel>> GetTestSuite(RestClient client)
        {
            var projectId = await CreatingProjectStep.GetTestProjectId(client);
            var suite = TestSuiteFactory.GetTestSuite();
            var response = await RequestProcessor.AddTestSuite(projectId, suite, client);
            _log.Info("The new project with test suite was created");

            return response;
        }
    }
}