using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaspberryLights.Application.Commands.StartAnimation;
using RaspberryLights.Application.Commands.UpdateDeviceIp;

namespace RaspberryLights.Mvc.Controllers;

public class DeviceController : Controller
{
    private readonly IMediator _mediator;

    public DeviceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateIp([FromBody] UpdateDeviceIpCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> StartAnimation(StartAnimationCommand startAnimationCommand)
    {
        await _mediator.Send(startAnimationCommand);
        return RedirectToAction("Index", "RaspberryLights");
    }

    [HttpGet]
    public Task<IActionResult> CheckConnection()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}