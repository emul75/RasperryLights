using MediatR;
using Microsoft.EntityFrameworkCore;
using RaspberryLights.Application.Commands.UpdateDeviceIp;
using RaspberryLights.Application.Interfaces;

namespace RaspberryLights.Application.Commands.UpdateDevice;

public class UpdateRaspberryIpCommandHandler : IRequestHandler<UpdateDeviceCommand>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public UpdateRaspberryIpCommandHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _dbContext.Devices.FirstOrDefaultAsync(w => w.Id == request.DeviceId, cancellationToken)
                    ?? throw new DeviceNotFoundException();

        if (request.Name is not null)
            device.Name = request.Name;

        if (request.RegistrationPlate is not null)
            device.RegistrationPlate = request.RegistrationPlate;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}