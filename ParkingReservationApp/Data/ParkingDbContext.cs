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
        // Map each entity to the corresponding table in the SQLite database
        // otherwise Entity Framework will use pluralization.        
        modelBuilder.Entity<Contact>()
            .ToTable("contact");
        modelBuilder.Entity<Employee>()
            .ToTable("employee");
        modelBuilder.Entity<Bookee>()
            .ToTable("bookee");
        modelBuilder.Entity<Booking>()
            .ToTable("booking");
        modelBuilder.Entity<ParkingSpace>()
            .ToTable("parkingspace");
        modelBuilder.Entity<ParkingStructure>()
            .ToTable("parkingstructure");

        // Define composite primary keys
        modelBuilder.Entity<ParkingSpace>()
            .HasKey(ps => new { ps.ParkingSpaceId, ps.ParkingStructureId });

        // Define foreign keys
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.ParkingSpace)
            .WithMany()
            .HasForeignKey(b => new { b.ParkingSpaceId, b.ParkingStructureId });

    }
}