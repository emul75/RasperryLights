using MediatR;
using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Interfaces;

namespace RaspberryLights.Application.Commands.DeleteDevice;

public class DeleteDeviceCommandHandler(IRaspberryLightsDbContext dbContext) : IRequestHandler<DeleteDeviceCommand>
{
    public async Task Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await dbContext.Devices.SingleAsync(w => w.Id == request.DeviceId, cancellationToken: cancellationToken);
        dbContext.Devices.Remove(device);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}