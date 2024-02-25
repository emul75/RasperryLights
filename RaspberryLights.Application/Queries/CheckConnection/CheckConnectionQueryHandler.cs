using MediatR;
using RaspberryLights.Application.Interfaces;
using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Application.Queries.CheckConnection;

public class CheckConnectionQueryHandler : IRequestHandler<CheckConnectionQuery, ConnectionStatus>
{
    private readonly IRaspberryLightsDbContext _dbContext;

    public CheckConnectionQueryHandler(IRaspberryLightsDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ConnectionStatus> Handle(CheckConnectionQuery request, CancellationToken cancellationToken)
    {
        if (request.DeviceUrl is null)
            return ConnectionStatus.Disconnected;

        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, errors) => true
        };

        using var client = new HttpClient(handler);
        var startAnimationUrl = $"{request.DeviceUrl}/Led/testConnection";

        try
        {
            var response = await client.GetAsync(startAnimationUrl, cancellationToken);
            return response.IsSuccessStatusCode ? ConnectionStatus.Connected : ConnectionStatus.Disconnected;
        }
        catch (HttpRequestException)
        {
            return ConnectionStatus.Disconnected;
        }
    }
}