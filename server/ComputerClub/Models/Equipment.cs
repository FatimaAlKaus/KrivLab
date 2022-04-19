namespace ComputerClub.Models
{
    public class Equipment : Entity
    {
        public string CPU { get; set; }
        public string VideoCard { get; set; }
        public string Monitor { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string Mouse { get; set; }
        public string Keyboard { get; set; }
        public Place Place { get; set; }
    }
}
