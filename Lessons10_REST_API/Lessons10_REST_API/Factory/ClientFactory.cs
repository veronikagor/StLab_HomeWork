using Bogus;
using Lessons10_REST_API.Models;

namespace Lessons10_REST_API.Factory
{
    public class ClientFactory
    {
        public static Client GetInvalidCredential()
        {
            return new Faker<Client>()
                .RuleFor(p => p.UserName, f => f.Internet.UserName())
                .RuleFor(p => p.Password, f => f.Internet.Password(21));
        }
    }
}