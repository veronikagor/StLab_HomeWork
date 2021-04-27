using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessons10_REST_API.Enum;
using Lessons10_REST_API.Helper;

namespace Lessons10_REST_API.Steps
{
    public static class GettingProjectsStep
    {
        public static async Task<List<int>> GetProjectsId()
        {
            var response = await RequestProcessor.GetProjects(Authorization.GetAuthorizedClient(TypeOfRights.Admin));
            return response.Data.Select(project => project.Id).ToList();
        }
    }
}