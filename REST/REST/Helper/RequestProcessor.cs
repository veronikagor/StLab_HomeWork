using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Models.TestSuiteModels;
using Lessons10_REST_API.Services;
using RestSharp;

namespace Lessons10_REST_API.Helper
{
    public class RequestProcessor
    {
        public static async Task<IRestResponse<ProjectResponseModel>> AddTestSuite(object projectId,
            TestSuiteRequestModel data, RestClient client)
        {
            var endPoint = Path.Combine(Configurator.AddSuiteUrlEndPoint, projectId.ToString());
            var response = RequestHelper.BuildRequest(endPoint, Method.POST, data, client);
            return await response;
        }

        public static Task<IRestResponse<ProjectResponseModel>> UpdateTestSuite(object suiteId,
            TestSuiteRequestModel data, RestClient client)
        {
            var endPoint = Path.Combine(Configurator.UpdateSuiteUrlEndPoint, suiteId.ToString());
            var response = RequestHelper.BuildRequest(endPoint, Method.POST, data, client);
            return response;
        }

        public static async Task<IRestResponse<ProjectResponseModel>> AddProject(ProjectRequestModel data,
            RestClient client)
        {
            var endPoint = Configurator.AddProjectUrlEndPoint;
            var response = RequestHelper.BuildRequest(endPoint, Method.POST, data, client);
            return await response;
        }

        public static Task<IRestResponse<ProjectResponseModel>> GetProject(object projectId, RestClient client)
        {
            var endPoint = Path.Combine(Configurator.GetProjectUrlEndPoint, projectId.ToString());
            var response = RequestHelper.BuildRequest(endPoint, Method.GET, client);
            return response;
        }

        public static Task<IRestResponse<List<ProjectResponseModel>>> GetProjects(RestClient client)
        {
            var endPoint = Configurator.GetProjectsUrlEndPoint;
            var response = RequestHelper.BuildRequestToGetAllProjects(endPoint, Method.GET, client);
            return response;
        }

        public static Task<IRestResponse<ProjectResponseModel>> DeleteProject(object projectId, RestClient client)
        {
            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint, projectId.ToString());
            var response = RequestHelper.BuildRequest(endPoint, Method.POST, client);
            return response;
        }
    }
}