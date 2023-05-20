using Microsoft.EntityFrameworkCore;
using PMS.Common.Entities;

namespace PMS.Data.Entities;

/// <summary>
/// The PMS Database Context Class
/// </summary>
public partial class PmsdatabaseContext : DbContext
{
    /// <summary>
    /// Create a new instance of <see cref="PmsdatabaseContext"/> class
    /// </summary>
    public PmsdatabaseContext()
    {
    }

    /// <summary>
    /// Create a new instance of <see cref="PmsdatabaseContext"/> class
    /// </summary>
    public PmsdatabaseContext(DbContextOptions<PmsdatabaseContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// The User Entity
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// The Product Entity
    /// </summary>
    public virtual DbSet<Product> Products { get; set; }

    /// <summary>
    /// The On Configuring DB
    /// </summary>
    /// <param name="optionsBuilder">The DB Context Options Builder</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    /// <summary>
    /// The On Model Creation
    /// </summary>
    /// <param name="modelBuilder">The Model builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.UserName).IsRequired();
            entity.Property(e => e.EmailId).IsRequired();
            entity.Property(e => e.ContactNumber).IsRequired();
            entity.Property(e => e.IsActive).IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");
            entity.Property(e => e.ProductName).IsRequired();
            entity.Property(e => e.ProductGuid).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.IsActive).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    /// <summary>
    /// The Partial Model Creation Method
    /// </summary>
    /// <param name="modelBuilder">The Model Builder</param>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
