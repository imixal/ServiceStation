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
                var client2 = new Client()
                {
                    FirstName = "Jack",
                    LastName = "Will",
                    DateOfBirth = "29-04-1980",
                    Address = "62 Sam Street London",
                    Phone = "+44 0 5674 357233",
                    Email = "example@test.ru"
                };
                uow.Clients.Add(client1);
                uow.Clients.Add(client2);
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
                var auto3 = new Auto()
                {
                    Make = "Mazda",
                    Model = "RAV4",
                    Year = 2014,
                    VIN = "JMR11BE2217683274"
                };
                auto3.ClientAuto = client2;
                uow.Cars.Add(auto3);
                uow.Save();

                client1.Cars.Add(auto1);
                client1.Cars.Add(auto2);

                var order1 = new Order
                {
                    Date = new DateTime(2016, 10, 20),
                    OrderAmount = 3350,
                    OrderAuto = auto1,
                    Status = "In Progress"
                };
                order1.OrderClient = client1;
                uow.Orders.Add(order1);

                var order3 = new Order
                {
                    Date = new DateTime(2014, 11, 04),
                    OrderAmount = 8700,
                    OrderAuto = auto3,
                    Status = "Cancelled"
                };
                order3.OrderClient = client2;
                uow.Orders.Add(order3);

                var order2 = new Order()
                {
                    Date = new DateTime(2015, 11, 20),
                    OrderAmount = 1500,
                    OrderAuto = auto2,
                    Status = "Completed"
                };
                order2.OrderClient = client1;
                uow.Orders.Add(order2);
                uow.Save();
            }
        }
    }
}
