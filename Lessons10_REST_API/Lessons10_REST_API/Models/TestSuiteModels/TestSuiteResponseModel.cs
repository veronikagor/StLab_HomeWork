using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lessons10_REST_API.Models.TestSuiteModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TestSuiteResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CompletedOn { get; set; }

        public bool IsMaster { get; set; }

        public bool IsBaseline { get; set; }

        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }

        public string Url { get; set; }
    }
}