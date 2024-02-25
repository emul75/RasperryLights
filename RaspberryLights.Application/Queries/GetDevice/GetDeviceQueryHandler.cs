using MediatR;
using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Queries.GetDevice;

public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, Device>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public GetDeviceQueryHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Device> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.HasValue)
            return await _dbContext.Devices.FirstOrDefaultAsync(w => w.Id == request.Id.Value, cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.RegistrationPlate))
            return await _dbContext.Devices.FirstOrDefaultAsync(w => w.RegistrationPlate == request.RegistrationPlate,
                cancellationToken); // tudu

        throw new ArgumentException("At least one search criteria must be provided.");
    }
}