namespace ParkProject.Data.Models
{
    public class ZonePlant
    {
        public int ZoneId { get; set; }
        public int PlantId { get; set; }
        public string Density { get; set; }

        public Zone Zone { get; set; }
        public PlantSpecies PlantSpecies { get; set; }
    }
}
