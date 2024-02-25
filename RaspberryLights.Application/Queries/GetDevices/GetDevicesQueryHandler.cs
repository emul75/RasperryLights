using MediatR;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Queries.GetDevices;

public class GetDevicesQueryHandler : IRequestHandler<GetDevicesQuery, IEnumerable<Device>>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public GetDevicesQueryHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Device>> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<Device>>(_dbContext.Devices.Where(w => w.UserId == request.UserId || request.UserId == null));
    }
}