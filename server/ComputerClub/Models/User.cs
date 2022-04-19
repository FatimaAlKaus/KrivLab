using System.Collections.Generic;

namespace ComputerClub.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
