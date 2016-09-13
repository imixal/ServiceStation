using ServiceStation.DataAccessLayer.UnitOfWork;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Services
{
    public class AutoService
    {
        public static List<Auto> GetCars(int skip = 0, int take = 100)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Cars.GetItems(skip, take);
            }
        }
        public static void AddAuto(Auto auto, int client)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Cars.Add(auto);
                auto.ClientAuto = uow.Clients.GetClient(client);
                uow.Save();
            }
        }
        public static void DeleteAuto( int autoId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.Cars.Delete(uow.Cars.GetById(autoId));
                uow.Save();
            }
        }
    }
}
