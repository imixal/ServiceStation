using System.Collections.Generic;

namespace ServiceStation.Models
{
    public class Auto:Entity
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string VIN { get; set; }

        public ICollection<Client> Clients { get; set; }
         
        public ICollection<Order> Orders { get; set; }

    }
}
