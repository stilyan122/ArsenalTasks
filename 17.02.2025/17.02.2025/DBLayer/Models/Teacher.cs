﻿namespace DBLayer
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? TeacherCode { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? WorkingDays { get; set; }
    }
}
