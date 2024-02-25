using Microsoft.EntityFrameworkCore;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Interfaces;

public interface IRaspberryLightsDbContext
{
    DbSet<Device> Devices { get; set; }
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}