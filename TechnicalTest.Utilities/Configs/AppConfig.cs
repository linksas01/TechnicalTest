using Microsoft.Extensions.Configuration;
using TechnicalTest.Utilities.Configs;

namespace TechnicalTest.Utilities.Configs
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _config;

        public AppConfig(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString => _config.GetConnectionString("TechnicalTestConnectionString")!;

        public string SecretKey => _config.GetSection("Settings:SecretKey").Value!;

        public string MaxHours => _config.GetSection("Messages:MaxHours").Value!;

        public string LeaderNotFound => _config.GetSection("Messages:LeaderNotFound").Value!;        
    }
}