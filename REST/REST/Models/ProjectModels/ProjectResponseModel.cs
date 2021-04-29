using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lessons10_REST_API.Models.ProjectModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ProjectResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Announcement { get; set; }

        public int CompletedOn { get; set; }

        public bool IsCompleted { get; set; }

        public int SuiteMode { get; set; }

        public bool ShowAnnouncement { get; set; }

        public string Url { get; set; }
    }
}