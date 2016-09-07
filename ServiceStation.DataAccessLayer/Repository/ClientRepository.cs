using ServiceStation.Models;
using System.Data.Entity;

namespace ServiceStation.DataAccessLayer.Repository
{
    class ClientRepository:Repository<Client>
    {
        public ClientRepository(DbContext context)
            : base(context)
        {

        }
    }
}
