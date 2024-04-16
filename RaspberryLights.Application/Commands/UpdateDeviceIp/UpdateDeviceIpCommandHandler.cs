using MediatR;
using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Exceptions;

namespace RaspberryLights.Application.Commands.UpdateDeviceIp;

public class UpdateRaspberryIpCommandHandler : IRequestHandler<UpdateDeviceIpCommand>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public UpdateRaspberryIpCommandHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateDeviceIpCommand request, CancellationToken cancellationToken)
    {
        var device = await _dbContext.Devices.FirstOrDefaultAsync(w => w.Id == request.DeviceId,
                        cancellationToken)
                    ?? throw new DeviceNotFoundException();

        device.ConnectionUrl = request.NewIp;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}