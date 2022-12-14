using Food.Models;
using Food.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Food.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Menu> Menus { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Employee>()
           .HasOne(e => e.Manager)
           .WithMany()
           .HasForeignKey(m => m.ManagerID); // t = ReportsTo 
      
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        builder.Entity<Employee>().ToTable("Employee");
        builder.Entity<Restaurant>().ToTable("Restaurant");
        builder.Entity<Location>().ToTable("Location");
        builder.Entity<Menu>().ToTable("Menu");
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}

