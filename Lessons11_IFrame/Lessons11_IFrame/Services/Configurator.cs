﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Lessons11_IFrame.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];// ередает как стрингу
      
        public static string BrowserType => Configuration[nameof(BrowserType)];// ередает как стрингу
        
        public static int WaitTimeOut => int.Parse(Configuration[nameof(WaitTimeOut)]);// ередает как стрингу!!!
        
        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsetings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsetings.*.json");
            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();

        }
    }
}