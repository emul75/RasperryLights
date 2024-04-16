using System.Text.Json;
using MediatR;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Exceptions;
using RaspberryLights.Domain.Models;

namespace RaspberryLights.Application.Queries.GetCurrentAnimationParameters;

public class GetCurrentAnimationParametersQueryHandler(IRaspberryLightsDbContext dbContext)
    : IRequestHandler<GetCurrentAnimationParametersQuery, AnimationParameters>
{
    public async Task<AnimationParameters> Handle(GetCurrentAnimationParametersQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var device = await dbContext.Devices.FindAsync([request.DeviceId], cancellationToken: cancellationToken)
                         ?? throw new DeviceNotFoundException();

            var deviceConnectionUrl = device.ConnectionUrl;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, errors) => true
            };

            using var httpClient = new HttpClient(handler);
            var startAnimationUrl = $"{deviceConnectionUrl}/Led/getCurrentAnimationParameters";


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
        catch (HttpRequestException)
        {
            return new AnimationParameters();
        }
        catch (InvalidOperationException) // todo - custom exception if ConnectionUrl is invalid
        {
            return new AnimationParameters();
        }
    }
}