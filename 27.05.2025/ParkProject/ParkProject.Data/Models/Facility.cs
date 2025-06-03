namespace ParkProject.Data.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public string Condition { get; set; }
        public DateTime InstalledOn { get; set; }

        public Zone Zone { get; set; }
    }
}
