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
                //"C:\\inetpub\\wwwroot\\TestApi"
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\GCall.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }
        static public string IdentityConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\GCall.Api"));
                configurationManager.AddJsonFile("appsettings.json");
                

                return configurationManager.GetConnectionString("AspCoreIdentitySqlServer");
            }
        }
    }
}
