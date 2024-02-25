using MediatR;
using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Interfaces;

namespace RaspberryLights.Application.Commands.DeleteDevice;

public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public DeleteDeviceCommandHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _dbContext.Devices.SingleAsync(w => w.Id == request.DeviceId, cancellationToken: cancellationToken);
        _dbContext.Devices.Remove(device);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}