using System.IO;
using System.Threading.Tasks;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Services;
using Newtonsoft.Json;
using RestSharp;

namespace Lessons10_REST_API.Helper
{
    public static class RequestHelper
    {
        public static async Task<IRestResponse<ProjectResponseModel>> BuildRequestWithData(string endpoint,
            Method method, object data, RestClient client)
        {
            var url = Path.Combine(Configurator.BaseUrl, endpoint);

            var request = new RestRequest(url, method)
                .AddHeader("Accept", "application/json")
                .AddHeader("Content-Type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(data));
            return await client.ExecuteAsync<ProjectResponseModel>(request);
        }

        public static async Task<IRestResponse<ProjectResponseModel>> BuildRequestWithoutData(string endpoint,
            Method method, RestClient client)
        {
            var url = Path.Combine(Configurator.BaseUrl, endpoint);

            var request = new RestRequest(url, method)
                .AddHeader("Accept", "application/json")
                .AddHeader("Content-Type", "application/json");
            return await client.ExecuteAsync<ProjectResponseModel>(request);
        }
    }
}