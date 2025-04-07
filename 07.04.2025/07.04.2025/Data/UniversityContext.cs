using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<University> Universities { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Major> Majors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database=UniversityDB; " +
                "Integrated Security = True; Connect Timeout = 30; Encrypt = True; " +
                "Trust Server Certificate=False; Application Intent = ReadWrite; " +
                "Multi Subnet Failover=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
