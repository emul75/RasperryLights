using MediatR;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Commands.AddNewDevice;

public class AddNewDeviceCommandHandler : IRequestHandler<AddNewDeviceCommand, Device>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public AddNewDeviceCommandHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Device> Handle(AddNewDeviceCommand request, CancellationToken cancellationToken)
    {
        var newDevice = new Device
        {
            Id = request.DeviceId,
            Name = request.Name,
            Type = request.Type,
            RegistrationPlate = request.RegistrationPlate,
            ConnectionUrl = null,
            UserId = new Guid("656503f8-b307-4b34-96d5-2ecfc9d64e38")
        };
        
        _dbContext.Devices.Add(newDevice);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return newDevice;
    }
}