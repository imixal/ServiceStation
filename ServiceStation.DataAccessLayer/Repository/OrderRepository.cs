using ServiceStation.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ServiceStation.DataAccessLayer.Repository
{
    public class OrderRepository:Repository<Order>
    {
        public OrderRepository(DbContext context):
            base(context)
        {

        }
        public override List<Order> GetItems(int skip, int take)
        {
            return new List<Order>(Context.Set<Order>()
                .Include(GetItems => GetItems.OrderAuto)
                .Include(item => item.OrderClient)
                .OrderByDescending(item => item.Date)
                .Skip(skip)
                .Take(take));
        }
    }
}
