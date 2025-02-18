namespace DBLayer
{
    public class Student
    {
        public int Id { get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int ClassId { get; set; }
        public bool IsActive { get; set; }
    }
}
