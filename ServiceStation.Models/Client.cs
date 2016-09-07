using System.Collections.Generic;

namespace ServiceStation.Models
{
    public class Client:Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<Auto> Cars { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
