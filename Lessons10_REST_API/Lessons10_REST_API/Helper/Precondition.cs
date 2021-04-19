using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Models;
using Lessons10_REST_API.Models.ProjectModels;
using Lessons10_REST_API.Services;
using Lessons10_REST_API.Steps;
using RestSharp;

namespace Lessons10_REST_API.Helper
{
    public class Precondition
    {
        public static ProjectResponseModel GetProject()
        {
            var projectRequestModel = ProjectFactory.GetProjectWithCorrectValues();
            var request = CreatingRequest.CreateProjectRequest(Configurator.AddProjectUrlEndPoint, projectRequestModel,
                Method.POST);
            var response =
                GettingResponse.GetProjectResponse(UserAuthorization.GetAuthorizedClient(TypeOfRights.Admin), request);
            return GettingResponse.GetProjectResponseContent(response.Result);
        }
    }
}