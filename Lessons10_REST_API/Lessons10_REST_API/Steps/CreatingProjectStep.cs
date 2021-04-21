using System.Threading.Tasks;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Models.ProjectModels;
using RestSharp;

namespace Lessons10_REST_API.Steps
{
    public static class CreatingProjectStep
    {
        public static async Task<IRestResponse<ProjectResponseModel>> GetTestProject(RestClient client) //delete client
        {
            var projectModel = ProjectFactory.GetProjectWithCorrectValues();
            var response = await RequestProcessor.AddProject(projectModel, client);

            return response;
        }
    }
}