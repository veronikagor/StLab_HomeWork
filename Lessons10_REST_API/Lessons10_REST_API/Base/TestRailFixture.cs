using System;
using Lessons10_REST_API.Enum;
using Lessons10_REST_API.Helper;
using Lessons10_REST_API.Steps;
using RestSharp;

namespace Lessons10_REST_API.Base
{
    public class TestRailFixture : IDisposable
    {
        public RestClient Admin { get; }
        public RestClient User { get; }
        public RestClient UnAuthorisedClient { get; }

        public TestRailFixture()
        {
            Admin = UserAuthorization.GetAuthorizedClient(TypeOfRights.Admin);
            User = UserAuthorization.GetAuthorizedClient(TypeOfRights.User);
            UnAuthorisedClient = UserAuthorization.GetUnAuthorizedClient();
        }

        public void Dispose()
        {
        }
    }
}