using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Lessons10_REST_API.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];

        public static string AdminUserName => Configuration[nameof(AdminUserName)];

        public static string AdminPassword => Configuration[nameof(AdminPassword)];

        public static string UserName => Configuration[nameof(UserName)];

        public static string Password => Configuration[nameof(Password)];

        public static string AddProjectUrlEndPoint => Configuration[nameof(AddProjectUrlEndPoint)];

        public static string GetProjectUrlEndPoint => Configuration[nameof(GetProjectUrlEndPoint)];
        
        public static string GetProjectsUrlEndPoint => Configuration[nameof(GetProjectsUrlEndPoint)];

        public static string DeleteProjectUrlEndPoint => Configuration[nameof(DeleteProjectUrlEndPoint)];

        public static string AddSuiteUrlEndPoint => Configuration[nameof(AddSuiteUrlEndPoint)];

        public static string UpdateSuiteUrlEndPoint => Configuration[nameof(UpdateSuiteUrlEndPoint)];

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}