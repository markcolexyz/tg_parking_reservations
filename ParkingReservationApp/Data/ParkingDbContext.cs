using Microsoft.EntityFrameworkCore;

public class ParkingDbContext : DbContext
{
    public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Bookee> Bookees { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    public DbSet<ParkingStructure> ParkingStructures { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingSpace>()
            .HasKey(ps => new { ps.ParkingSpaceId, ps.ParkingStructureId });

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.ParkingSpace)
            .WithMany()
            .HasForeignKey(b => new { b.ParkingSpaceId, b.ParkingStructureId });

    }
}