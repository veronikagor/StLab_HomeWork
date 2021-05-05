using System.Threading.Tasks;
using Lessons10_REST_API.Factories;
using Lessons10_REST_API.Helper;
using NLog;
using RestSharp;

namespace Lessons10_REST_API.Steps
{
    public static class CreatingProjectStep
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public static async Task<int> GetTestProjectId(RestClient client)
        {
            var projectModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(projectModel, client);
            _log.Info("The new project was created");

            return response.Data.Id;
            ;
        }
    }
}