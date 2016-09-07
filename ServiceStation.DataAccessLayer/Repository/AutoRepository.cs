using ServiceStation.Models;
using System.Data.Entity;

namespace ServiceStation.DataAccessLayer.Repository
{
    class AutoRepository:Repository<Auto>
    {
        public AutoRepository(DbContext context)
            : base(context)
        {

        }
    }
}
