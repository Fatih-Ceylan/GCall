using Microsoft.Extensions.Configuration;

namespace GCall.Persistence.Services
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\fatih.ceylan\\source\\repos\\GCall\\GCall.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
