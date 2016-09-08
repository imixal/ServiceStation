using ServiceStation.DataAccessLayer.UnitOfWork;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DataBaseInit
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var client1 = new Client()
                {
                    FirstName = "Jim",
                    LastName = "Smith",
                    DateOfBirth = "26-01-1982",
                    Address = "12 Bell Street London",
                    Phone = "+44 0 1865 332233",
                    Email = "example@test.ru"
                };
                uow.Clients.Add(client1);
                uow.Save();

                var auto1 = new Auto() {
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2006,
                    VIN = "JTC11BE2216381074" };
                auto1.ClientAuto = client1;
                uow.Cars.Add(auto1);
                var auto2 = new Auto() {
                    Make = "Toyota",
                    Model = "Corolla",
                    Year = 2007,
                    VIN = "JTC11BE2216383274" };
                auto2.ClientAuto = client1;
                uow.Cars.Add(auto2);
                uow.Save();

                client1.Cars.Add(auto1);
                client1.Cars.Add(auto2);

                var order1 = new Order();
                order1.Date = "26-01-1982";
                order1.OrderAmount = 3350;
                order1.OrderAuto = auto1;
                order1.Status = "In Progress";
                order1.OrderClient = client1;
                uow.Orders.Add(order1);
                uow.Save();
            }
        }
    }
}
