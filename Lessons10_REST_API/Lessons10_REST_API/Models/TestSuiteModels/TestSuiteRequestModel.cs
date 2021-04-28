using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lessons10_REST_API.Models.TestSuiteModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TestSuiteRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}