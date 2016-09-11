using ServiceStation.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ServiceStation.DataAccessLayer.Repository
{
    public class ClientRepository:Repository<Client>
    {
        public ClientRepository(DbContext context)
            : base(context)
        {

        }
        public List<Client> FindClientbyFNandLN(string FName, string LName)
        {
           return new List<Client>( GetAllQuery().Where(client => client.FirstName == FName && client.LastName == LName));
        }
        public  Client GetClient(int id)
        {  
            return Context.Set<Client>().Include(item => item.Cars).Include(item => item.Orders).First(item => item.Id == id);
        }
    }
}
