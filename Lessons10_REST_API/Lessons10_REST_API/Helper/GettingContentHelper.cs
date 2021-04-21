using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Models.TestSuiteModels;
using Newtonsoft.Json;
using RestSharp;

namespace Lessons10_REST_API.Helper
{
    public static class GettingContentHelper
    {
        public static ProjectResponseModel GetProjectResponseContent(IRestResponse response)
        {
            var result = response.Content;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<ProjectResponseModel>(result);
        }

        public static TestSuiteResponseModel GetTestSuiteResponseContent(IRestResponse response)
        {
            var result = response.Content;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JsonConvert.DeserializeObject<TestSuiteResponseModel>(result);
        }
    }
}