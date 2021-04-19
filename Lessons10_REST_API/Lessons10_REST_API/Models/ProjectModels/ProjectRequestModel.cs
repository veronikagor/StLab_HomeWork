using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lessons10_REST_API.Models.ProjectModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ProjectRequestModel
    {
        public string Name { get; set; }

        public string Announcement { get; set; }

        public bool ShowAnnouncement { get; set; }

        public int SuiteMode { get; set; }
    }
}