using System.Text.Json;
using MediatR;
using RaspberryLights.Application.Commands.UpdateDeviceIp;
using RaspberryLights.Application.Interfaces;
using RaspberryLightsWebApi.Models;

namespace RaspberryLights.Application.Queries.GetCurrentAnimationParameters;

public class GetCurrentAnimationParametersQueryHandler : IRequestHandler<GetCurrentAnimationParametersQuery, AnimationParameters>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public GetCurrentAnimationParametersQueryHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AnimationParameters> Handle(GetCurrentAnimationParametersQuery request,
        CancellationToken cancellationToken)
    {
        var deviceConnectionUrl =
            (await _dbContext.Devices.FindAsync(new object?[] { request.DeviceId },
                cancellationToken: cancellationToken))?
            .ConnectionUrl
            ?? throw new DeviceNotFoundException();

        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, errors) => true
        };

        using var httpClient = new HttpClient(handler);
        var startAnimationUrl = $"{deviceConnectionUrl}/Led/getCurrentAnimationParameters";

        try
        {
            var response = await httpClient.GetAsync(startAnimationUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var animationParameters = await JsonSerializer.DeserializeAsync<AnimationParameters>(
                    await response.Content.ReadAsStreamAsync(cancellationToken),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
                    cancellationToken);

                return animationParameters
                       ?? throw new Exception(); // todo - custom exception
            }

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }
        catch (HttpRequestException e)
        {
            throw new Exception("Unable to connect to the device.", e);
        }
    }
}