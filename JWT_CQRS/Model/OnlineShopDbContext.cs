using Core.Entities;
using Core.Entities.Security;
using Core.FluentAPIConfigurations;
using Microsoft.EntityFrameworkCore;

public class OnlineShopDbContext : DbContext
{
    public OnlineShopDbContext(DbContextOptions options) : base(options)
    {
    }

    //public DbSet<Product> Products {get; set;}
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRefreshToken> UserRefreshTokens => Set<UserRefreshToken>(); 
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //    modelBuilder.Entity<Product>()
        //             .Property(s => s.ProductName)
        //             .HasColumnName("Title")
        //             .IsRequired();

        //    modelBuilder.Entity<Product>().ToTable("MyProduct");

        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserRefreshTokenEntityConfiguration());

    }
}