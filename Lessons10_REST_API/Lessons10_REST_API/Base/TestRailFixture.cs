using System;
using Lessons10_REST_API.Enum;
using Lessons10_REST_API.Helper;
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
            Admin = Authorization.GetAuthorizedClient(TypeOfRights.Admin);
            User = Authorization.GetAuthorizedClient(TypeOfRights.User);
            UnAuthorisedClient = Authorization.GetUnAuthorizedClient();
        }

        public void Dispose()
        {
        }
    }
}