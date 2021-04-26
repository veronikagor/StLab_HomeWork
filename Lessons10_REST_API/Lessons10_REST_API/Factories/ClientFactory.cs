using System.ComponentModel.DataAnnotations;
using Bogus;
using Lessons10_REST_API.Constants;
using Lessons10_REST_API.Models;

namespace Lessons10_REST_API.Factories
{
    public static class ClientFactory
    {
        public static Client GetInvalidCredential()
        {
            return new Faker<Client>("en")
                .RuleFor(p => p.UserName, f => f.Internet.Email())
                .RuleFor(p => p.Password, f => f.Internet.Password(CredentialConstants.PasswordLength));
        }
    }
}