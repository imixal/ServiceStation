using ServiceStation.DataAccessLayer.UnitOfWork;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceStation.Services
{
    public class OrderService
    {
        public static List<Order> GetOrders(int skip = 0, int take = 100)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Orders.GetItems(skip, take);
            }
        }
        public static void ChangeOrder(int orderId, double orderAmount, string status)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var order = uow.Orders.GetById(orderId);
                order.OrderAmount = orderAmount;
                order.Status = status;
                uow.Orders.Update(order);
                uow.Save();
            }
        }
        public static void AddOrder(string d, double orderAmount, string status, int clientId, int autoId)
        {
            var date = d.Split('/');
            var dateTime = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
            var order = new Order() { Date = dateTime, OrderAmount = orderAmount, Status = status };
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Orders.Add(order);
                order.OrderClient = uow.Clients.GetClient(clientId);
                order.OrderAuto = uow.Cars.GetById(autoId);
                uow.Save();
            }
        }
        public static void DeleteOrder(int orderId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Orders.Delete(uow.Orders.GetById(orderId));
                uow.Save();
            }
        }
    }
}
