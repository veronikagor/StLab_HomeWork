using System.IO;
using Lessons10_REST_API.Models;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Models.TestSuiteModels;
using Lessons10_REST_API.Services;
using Newtonsoft.Json;
using RestSharp;
using static RestSharp.Serialization.ContentType;

namespace Lessons10_REST_API.Helper
{
    public class CreatingRequest
    {
        public static IRestRequest CreateProjectRequest(string endpoint, ProjectRequestModel data, Method method)
        {
            var url = Path.Combine(Configurator.BaseUrl, endpoint); 
            var request = new RestRequest(url, method)
                .AddHeader("Accept", Json)
                .AddHeader("Content-Type", Json);
            return request.AddJsonBody(JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public static IRestRequest CreateProjectRequest(string endpoint, Method method)
        {
            var url = Path.Combine(Configurator.BaseUrl, endpoint);
            return new RestRequest(url, method)
                .AddHeader("Content-Type", Json);
        }

        public static IRestRequest CreateTestSuiteRequest(string endpoint, TestSuiteRequestModel data, Method method)
        {
            var url = Path.Combine(Configurator.BaseUrl, endpoint); 
            var request = new RestRequest(url, method)
                .AddHeader("Accept", Json)
                .AddHeader("Content-Type", Json);
            return request.AddJsonBody(JsonConvert.SerializeObject(data, Formatting.Indented));
        }
        
    }
}