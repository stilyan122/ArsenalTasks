namespace ParkProject.Data.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal AreaHa { get; set; }

        public ICollection<ZonePlant> ZonePlants { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }
}
