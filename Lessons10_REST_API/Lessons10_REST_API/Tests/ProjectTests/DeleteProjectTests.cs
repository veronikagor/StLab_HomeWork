using System.IO;
using System.Net;
using Allure.Xunit.Attributes;
using Lessons10_REST_API.Base;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Services;
using Lessons10_REST_API.Utils;
using RestSharp;
using Xunit;

namespace Lessons10_REST_API.Tests.ProjectTests
{
    public class DeleteProjectTests : IClassFixture<TestRailFixture>
    {
        private TestRailFixture _fixture;
        private string _projectId;

        public DeleteProjectTests(TestRailFixture fixture)
        {
            _fixture = fixture;
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project with correct values")]
        [AllureXunit]	// existent Id
        public void DeleteProject_WithExistentProjectId_ShouldReturnOk()
        {
            _projectId = Precondition.GetProject().Id.ToString();

            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint,  _projectId);

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project with nonexistent project Id")]
        [AllureXunit] 
        public void DeleteProject_WithNonexistentProjectId_ShouldReturnBadRequest()
        {
             _projectId = Precondition.GetProject().Id.ToString();

            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint, _projectId );

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project with missing required values")]
        [AllureXunit] 
        public void DeleteProject_WhenMissingProjectId_ShouldReturnBadRequest()
        {
            var request = CreatingRequest.CreateProjectRequest(Configurator.DeleteProjectUrlEndPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project with incorrect format project Id")]
        [AllureXunitTheory]
        [MemberData(nameof(TestCaseSources.Cases), MemberType = typeof(TestCaseSources))]
        public void DeleteProject_WithIncorrectFormatProjectId_ShouldReturnBadRequest(object id)
        {
            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint, id.ToString());

            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.Admin, request);

            Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project when user is unauthorized")]
        [AllureXunit]
        public void DeleteProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            _projectId = Precondition.GetProject().Id.ToString();
            
            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint, _projectId); 
            
            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.UnAuthorisedClient, request);

            Assert.Equal(HttpStatusCode.Unauthorized, response.Result.StatusCode);
        }
        
        [AllureTag("Delete project")]
        [AllureSubSuite("Delete project without admin status")]
        [AllureXunit]
        public void DeleteProject_WithoutAdminStatus_ShouldReturnForbidden()
        {
           _projectId = Precondition.GetProject().Id.ToString();
            
            var endPoint = Path.Combine(Configurator.DeleteProjectUrlEndPoint, _projectId); 
            
            var request = CreatingRequest.CreateProjectRequest(endPoint, Method.POST);
            var response = GettingResponse.GetProjectResponse(_fixture.User, request);
            
            Assert.Equal(HttpStatusCode.Forbidden, response.Result.StatusCode);
        }
    }
}
