using System;
using System.Threading;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Interfaces.IClients;
using LMDriversDash.Services.Interfaces.IGameState;

namespace LMDriversDash.Services.Service.GameState;

public class GameStateService : IGameStateService
{
    private readonly IHttpClientService _httpClientService;
    private readonly IUdpClientService _udpClientService;
    
    // Cancellation Token to be abort infinite loop
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    
    // Polling Interval for Http
    private TimeSpan _pollInterval = TimeSpan.FromSeconds(1);
    
    public LoadingStatus? LoadingStatus { get; set; }
    
    public State? CurrentState { get; set; }
    
    public HttpProfileInfo? HttpProfileInfo { get; set; }

    public GameStateService(IHttpClientService httpClientService, IUdpClientService udpClientService)
    {
        _httpClientService = httpClientService;
        _udpClientService = udpClientService;
    }
    
    public Task RunOnStartupAsync()
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }
}