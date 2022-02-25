using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppConfiguration
    {
        public string SqlConnectionString { get; set; }

        public AppConfiguration()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            IConfigurationRoot root = configBuilder.Build();
            IConfigurationSection appSetting = root.GetRequiredSection("ConnectionStrings:DefaultConnection");
            SqlConnectionString = appSetting.Value;
        }
    }
}
