using System;
using Lessons10_REST_API.Factory;
using Lessons10_REST_API.Services;
using RestSharp;
using RestSharp.Authenticators;

namespace Lessons10_REST_API.Steps
{
    public class UserAuthorization
    {
        public static RestClient GetAuthorizedClient(TypeOfRights typeOfRights)
        {
            return typeOfRights switch
            {
                TypeOfRights.Admin => new RestClient()
                {
                    Authenticator =
                        new HttpBasicAuthenticator(Configurator.AdminUserName, Configurator.AdminPassword)
                },
                TypeOfRights.User => new RestClient()
                {
                    Authenticator = new HttpBasicAuthenticator(Configurator.UserName, Configurator.Password)
                },
                _ => new RestClient()
                {
                    Authenticator = new HttpBasicAuthenticator(Configurator.UserName, Configurator.Password)
                }
            };
        }

        public static RestClient GetUnAuthorizedClient()
        {
            return new RestClient()
            {
                Authenticator = new HttpBasicAuthenticator(ProjectFactory.GetInvalidCredential().UserName,
                    ProjectFactory.GetInvalidCredential().Password)
            };
        }
    }
}