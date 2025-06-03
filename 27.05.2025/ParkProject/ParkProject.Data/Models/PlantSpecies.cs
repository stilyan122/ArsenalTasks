namespace ParkProject.Data.Models
{
    public class PlantSpecies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public bool IsProtected { get; set; }
        public string Description { get; set; }

        public ICollection<ZonePlant> ZonePlants { get; set; }
    }
}
