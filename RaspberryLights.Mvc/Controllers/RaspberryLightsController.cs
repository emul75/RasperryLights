using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaspberryLights.Application.Commands.AddNewDevice;
using RaspberryLights.Application.Commands.DeleteDevice;
using RaspberryLights.Application.Commands.StartAnimation;
using RaspberryLights.Application.Commands.UpdateDevice;
using RaspberryLights.Application.Queries.CheckConnection;
using RaspberryLights.Application.Queries.GetCurrentAnimationParameters;
using RaspberryLights.Application.Queries.GetDevice;
using RaspberryLights.Application.Queries.GetDevices;
using RaspberryLights.Domain.Models;
using RaspberryLights.Mvc.Dtos;
using RaspberryLights.Mvc.Models;

namespace RaspberryLights.Mvc.Controllers;

public class RaspberryLightsController : Controller
{
    private readonly ILogger<RaspberryLightsController> _logger;
    private readonly IMediator _mediator;

    public RaspberryLightsController(ILogger<RaspberryLightsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var devices = await _mediator.Send(new GetDevicesQuery());

        var viewModel = new DeviceListViewModel { Devices = [] };

        foreach (var device in devices)
        {
            var deviceDto = DeviceDto.Map(device);
            deviceDto.ConnectionStatus = await _mediator.Send(new CheckConnectionQuery(device.ConnectionUrl));

            viewModel.Devices.Add(deviceDto);
        }

        return View(viewModel);
    }


    public async Task<IActionResult> DeviceDetails(Guid deviceId)
    {
        var device = await _mediator.Send(new GetDeviceQuery { Id = deviceId });
        var deviceDto = DeviceDto.Map(device);
        var currentAnimationParameters = await _mediator.Send(new GetCurrentAnimationParametersQuery(deviceId));
        var viewModel = new DeviceDetailsViewModel(deviceDto, currentAnimationParameters);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> EditDeviceDetails(Guid deviceId)
    {
        var device = await _mediator.Send(new GetDeviceQuery { Id = deviceId });
        var deviceDto = DeviceDto.Map(device);
        var viewModel = new DeviceDetailsViewModel(deviceDto, new AnimationParameters());

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SaveDeviceDetails(UpdateDeviceCommand command)
    {
        await _mediator.Send(command);

        var device = await _mediator.Send(new GetDeviceQuery(command.DeviceId));
        var deviceDto = DeviceDto.Map(device);
        var currentAnimationParameters = await _mediator.Send(new GetCurrentAnimationParametersQuery(device.Id));
        var viewModel = new DeviceDetailsViewModel(deviceDto, currentAnimationParameters);

        return View("DeviceDetails", viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> AddDevice()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SaveNewDevice(AddNewDeviceCommand command)
    {
        var device = await _mediator.Send(command);
        var deviceDto = DeviceDto.Map(device);
        var currentAnimationParameters = await _mediator.Send(new GetCurrentAnimationParametersQuery(device.Id));
        var viewModel = new DeviceDetailsViewModel(deviceDto, currentAnimationParameters);

        return View("DeviceDetails", viewModel);
    }

    public async Task<IActionResult> DeleteDevice(Guid deviceId)
    {
        await _mediator.Send(new DeleteDeviceCommand(deviceId));

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> StartAnimation(Guid deviceId, AnimationParameters animationParameters)
    {
        var command = new StartAnimationCommand
        {
            DeviceId = deviceId,
            AnimationParameters = animationParameters
        };

        await _mediator.Send(command);

        return RedirectToAction("DeviceDetails", new { deviceId = deviceId });
    }
}