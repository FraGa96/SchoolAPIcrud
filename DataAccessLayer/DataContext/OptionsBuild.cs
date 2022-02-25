using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataContext
{
    public class OptionsBuild
    {
        public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }

        public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }

        private AppConfiguration _appConfiguration { get; set; }

        public OptionsBuild()
        {
            _appConfiguration = new AppConfiguration();
            OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            OptionsBuilder.UseSqlServer(_appConfiguration.SqlConnectionString);

            DatabaseOptions = OptionsBuilder.Options;
        }
    }
}
