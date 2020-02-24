using System;
using Microsoft.Extensions.Configuration;

namespace Rudy.Common.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Database => _configuration["ConnectionStrings:fysdb"];
    }
}
