namespace DBLayer.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
    }
}
