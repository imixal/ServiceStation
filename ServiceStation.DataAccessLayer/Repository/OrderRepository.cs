using ServiceStation.Models;
using System.Data.Entity;

namespace ServiceStation.DataAccessLayer.Repository
{
    public class OrderRepository:Repository<Order>
    {
        public OrderRepository(DbContext context):
            base(context)
        {

        }
    }
}
