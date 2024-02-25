using System.Text;
using MediatR;
using RaspberryLights.Application.Queries.GetDevice;

namespace RaspberryLights.Application.Commands.StartAnimation;

public class StartAnimationCommandHandler : IRequestHandler<StartAnimationCommand>
{
    private readonly IMediator _mediator;

    public StartAnimationCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(StartAnimationCommand request, CancellationToken cancellationToken)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, errors) => true
        };

        var device = await _mediator.Send(new GetDeviceQuery(request.DeviceId), cancellationToken);

        using var client = new HttpClient(handler);

        var startAnimationUrl = $"{device.ConnectionUrl}/Led/startAnimation";

        var animationParametersJson = System.Text.Json.JsonSerializer.Serialize(request.AnimationParameters);
        var content = new StringContent(animationParametersJson, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(startAnimationUrl, content, cancellationToken);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("Connection failed.");
        }
    }
}
