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
        });
    }

}
