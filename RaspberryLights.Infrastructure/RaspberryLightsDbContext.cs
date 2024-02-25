using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Infrastructure;

public class RaspberryLightsDbContext : DbContext, IRaspberryLightsDbContext
{
    public RaspberryLightsDbContext(DbContextOptions<RaspberryLightsDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasDefaultSchema("OS"); // tudu

        modelBuilder.Entity<User>()
            .HasMany(u => u.Devices)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId);
    }
}