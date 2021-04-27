using System;
using Lessons10_REST_API.Enum;
using Lessons10_REST_API.Factories;
using Lessons10_REST_API.Services;
using RestSharp;
using RestSharp.Authenticators;

namespace Lessons10_REST_API.Helper
{
    public static class Authorization
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
                _ => throw new Exception("The user the type of rights must be defined!")
            };
        }

        public static RestClient GetUnAuthorizedClient()
        {
            return new RestClient()
            {
                Authenticator = new HttpBasicAuthenticator(ClientFactory.GetInvalidCredential().UserName,
                    ClientFactory.GetInvalidCredential().Password)
            };
        }
    }
}