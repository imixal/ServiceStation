using ServiceStation.DataAccessLayer.UnitOfWork;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Services
{
    public static class  ClientService
    {
       
        public static  List<Client> FindClientbyFNandLN(string FName, string LName)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return uow.Clients.FindClientbyFNandLN(FName, LName);
            }
        }
        public static Client GetById(int Id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Clients.GetClient(Id);
            }
        }
        public static void AddClient(Client client)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                uow.Clients.Add(client);
                uow.Save();
            }
        }
        
    }
}
