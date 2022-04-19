using System.Collections.Generic;

namespace ComputerClub.Models
{
    public class Status : Entity
    {
        public string Name { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
