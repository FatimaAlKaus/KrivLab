namespace ComputerClub.Models
{
    public class Order : Entity
    {
        public User Customer { get; set; }
        public Place Place { get; set; }

        public int Minutes { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
