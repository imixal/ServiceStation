using ServiceStation.Models;
using System.Data.Entity;

namespace ServiceStation.DataAccessLayer.Repository
{
   public class AutoRepository:Repository<Auto>
    {
        public AutoRepository(DbContext context)
            : base(context)
        {

        }
    }
}
