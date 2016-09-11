using ServiceStation.Models;
using System.Data.Entity;

namespace ServiceStation.DataAccessLayer.Context
{
    public class DataBaseContext : DbContext
    {
        private const string _dbConnectionStringName = "ServiceStationConnectionString";

        public DbSet<Client> CLients  { get; set; }

        public DbSet<Auto> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DataBaseContext(): base(_dbConnectionStringName)
        {
                
        }
    }
}
