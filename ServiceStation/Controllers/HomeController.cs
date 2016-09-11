using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStation.Services;
using ServiceStation.Models;

namespace ServiceStation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.orders = OrderService.GetOrders();
            ViewBag.cars = AutoService.GetCars();
            return View();
        }
        public ActionResult RefreshOrder()
        {
            ViewBag.orders = OrderService.GetOrders();
            return PartialView("_Orders");
        }
        public ActionResult RefreshAuto()
        {
            ViewBag.cars = AutoService.GetCars();
            return PartialView("_Cars");
        }
        public ActionResult Check(string FName, string LName)
        {
            var result =  ClientService.FindClientbyFNandLN(FName, LName);
            if(result.Count == 0)
            {
                return PartialView("_NullResult");
            }
            ViewBag.clients = result;
            return PartialView("_Registration");
        }
        public ActionResult GetAccount(int Id)
        {
            ViewBag.client = ClientService.GetById(Id);
            return PartialView("_Account");
        }
        public ActionResult GetOrders()
        {
            ViewBag.orders = OrderService.GetOrders();
            return PartialView("_Orders");
        }
        public ActionResult Register(string FirstName, string LastName, string DateOfBirht, string Address, string Phone, string Email)
        {
            var client = new Client() { FirstName = FirstName, LastName = LastName, DateOfBirth = DateOfBirht, Phone = Phone, Address = Address, Email = Email};
            ClientService.AddClient(client);
            var listClients = new List<Client>();
            listClients.Add(client);
            ViewBag.clients = listClients;
            return PartialView("_Registration");
        }
        
        public ActionResult AddAuto(string Make, string Model, int Year, string VIN, int clientId)
        {
            var auto = new Auto() { Make = Make, Model = Model, Year = Year, VIN = VIN};
            
            AutoService.AddAuto(auto,clientId);
            return GetAccount(clientId);
        }
        [HttpPost]
        public ActionResult DeleteAuto(int autoId, int clientId)
        {
            AutoService.DeleteAuto(autoId);
            return GetAccount(clientId);
        }
        [HttpPost]
        public ActionResult ChangeOrder(int orderId, double orderAmount, string status, int clientId)
        {
            OrderService.ChangeOrder(orderId, orderAmount, status);
            return GetAccount(clientId);
        }
        public ActionResult AddOrder(string date, double amount, string status, int clientId, int autoId)
        {
            OrderService.AddOrder(date, amount, status, clientId, autoId);
            return GetAccount(clientId);
        }
        public ActionResult DeleteOrder(int orderId, int clientId)
        {
            OrderService.DeleteOrder(orderId);
            return GetAccount(clientId);

        }

    }
}