using System.Collections.Generic;

namespace ComputerClub.Models
{
    public class Place : Entity
    {
        public decimal PricePerHour { get; set; }
        public Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Status Status { get; set; }
    }
}
