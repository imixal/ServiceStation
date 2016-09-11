using ServiceStation.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;



namespace ServiceStation.DataAccessLayer.Repository
{
   public class AutoRepository:Repository<Auto>
    {
        public AutoRepository(DbContext context)
            : base(context)
        {

        }
        public override List<Auto> GetItems(int skip, int take)
        {
            return new List<Auto>(Context.Set<Auto>()
                .Include(item => item.ClientAuto)
                .Include(item => item.Orders)
                .OrderByDescending(item => item.Id)
                .Skip(skip)
                .Take(take));
        }
    }
}
