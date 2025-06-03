using Microsoft.EntityFrameworkCore;
using ParkProject.Data.Models;

namespace ParkProject.Data
{
    public class ParkContext : DbContext
    {
        public ParkContext()
            : base()
        {
            
        }

        public ParkContext(DbContextOptions<ParkContext> options)
            : base(options)
        {
            
        }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<PlantSpecies> PlantSpecies { get; set; }
        public DbSet<ZonePlant> ZonePlants { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;" +
                "Database=NaturePark;Integrated Security=true;" +
             "TrustServerCertificate=True;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>(zone =>
            {
                zone.ToTable("zones");
                zone.HasKey(z => z.Id);

                zone.Property(z => z.Id)
                    .HasColumnName("id");

                zone.Property(z => z.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                zone.Property(z => z.Type)
                    .HasColumnName("type");

                zone.Property(z => z.AreaHa)
                    .HasColumnName("area_ha")
                    .HasColumnType("decimal(10,2)");

                zone.HasMany(z => z.Facilities)
                    .WithOne(f => f.Zone)
                    .HasForeignKey(f => f.ZoneId)
                    .OnDelete(DeleteBehavior.Restrict);

                zone.HasMany(z => z.ZonePlants)
                    .WithOne(zp => zp.Zone)
                    .HasForeignKey(zp => zp.ZoneId);
            });

            modelBuilder.Entity<PlantSpecies>(plant =>
            {
                plant.ToTable("plantspecies");
                plant.HasKey(p => p.Id);

                plant.Property(p => p.Id)
                     .HasColumnName("id");

                plant.Property(p => p.Name)
                     .IsRequired()
                     .HasColumnName("name");
                plant.HasIndex(p => p.Name)
                     .IsUnique();

                plant.Property(p => p.LatinName)
                     .IsRequired()
                     .HasColumnName("latin_name");
                plant.HasIndex(p => p.LatinName)
                     .IsUnique();

                plant.Property(p => p.IsProtected)
                     .HasColumnName("is_protected");

                plant.Property(p => p.Description)
                     .HasColumnName("description");

                plant.HasMany(p => p.ZonePlants)
                     .WithOne(zp => zp.PlantSpecies)
                     .HasForeignKey(zp => zp.PlantId);
            });

            modelBuilder.Entity<ZonePlant>(zp =>
            {
                zp.ToTable("zoneplants");
                zp.HasKey(x => new { x.ZoneId, x.PlantId });

                zp.Property(x => x.ZoneId)
                  .HasColumnName("zone_id");

                zp.Property(x => x.PlantId)
                  .HasColumnName("plant_id");

                zp.Property(x => x.Density)
                  .IsRequired()
                  .HasColumnName("density");

                zp.HasCheckConstraint(
                    "ck_zoneplant_density",
                    "density IN ('rare','medium','common')");
            });

            modelBuilder.Entity<Facility>(f =>
            {
                f.ToTable("facilities");
                f.HasKey(x => x.Id);

                f.Property(x => x.Id)
                 .HasColumnName("id");

                f.Property(x => x.ZoneId)
                 .HasColumnName("zone_id");

                f.Property(x => x.Type)
                 .IsRequired()
                 .HasColumnName("type");

                f.Property(x => x.Material)
                 .HasColumnName("material");

                f.Property(x => x.Condition)
                 .IsRequired()
                 .HasDefaultValue("good")
                 .HasColumnName("condition");

                f.Property(x => x.InstalledOn)
                 .HasColumnName("installed_on");
            });
        }
    }
}
