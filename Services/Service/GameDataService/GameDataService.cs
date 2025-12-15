using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Interfaces.IClients;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData.GameState;

namespace LMDriversDash.Services.Service.GameState;

public class GameDataService : IGameDataService
{
    // reaonly
    private readonly IHttpClientService _httpClientService;
    private readonly IUdpClientService _udpClientService;
    // Cancellation Token to be abort infinite loop
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    
    // Events
    public event EventHandler<HttpGameStateChangedEvent> HttpGameStateChanged;
    public event EventHandler<HttpProfileInfoReceivedEvent> HttpProfileInfoReceived;
    
    // Public Properties
    public LoadingStatus? LoadingStatus { get; set; }
    
    public State? CurrentState { get; set; }
    
    public HttpProfileInfo? HttpProfileInfo { get; set; }
    
    // private attributes
    // Polling Interval for Http
    private TimeSpan _pollInterval = TimeSpan.FromSeconds(1);
    
    public GameDataService(IHttpClientService httpClientService, IUdpClientService udpClientService)
    {
        _httpClientService = httpClientService;
        _udpClientService = udpClientService;
    }
    
    public async Task RunOnStartupAsync()
    {
        // HTTP GameState Polling
        _ = Task.Run(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    await PollGameState();
                    await Task.Delay(_pollInterval, _cancellationTokenSource.Token);
                }
            }, _cancellationTokenSource.Token
        );
    }

    private async Task PollGameState()
    {
        // Get current GameState from HTTP
        var newState = await _httpClientService.GetHttpGameStateAsync();
        if (newState != null) return;
        
        // Test for Changes
        var stateChanged = CurrentState?.NavigationState != newState?.NavigationState;
        var oldState = CurrentState;
        CurrentState = newState;

        if (stateChanged)
        {
            HttpGameStateChanged?.Invoke(this, new HttpGameStateChangedEvent(oldState, CurrentState));
            UpdatePollInterval(newState);
        }

        if (string.IsNullOrWhiteSpace(HttpProfileInfo?.Name))
        {
            try
            {
                // Get Profile if empty
                HttpProfileInfo = await _httpClientService.GetHttpProfileInfoAsync();
                if (!string.IsNullOrWhiteSpace(HttpProfileInfo?.Name))
                {
                    Debug.WriteLine($"GameDataService has loaded {HttpProfileInfo?.Name}'s profile info succesfully");
                    HttpProfileInfoReceived?.Invoke(this, new HttpProfileInfoReceivedEvent(HttpProfileInfo));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GameDataService::RunOnStartupAsync::PollGameState:: Line 73: HttpProfile threw an Exception");
            }
        }

        if (CurrentState.NavigationState == HttpGameStates.PlayerInPits || CurrentState.NavigationState == HttpGameStates.PlayerOnTrack)
        {
            //await LoadHttpGameData();
        }
    }

    private async Task LoadHttpGameData()
    {
        throw new NotImplementedException();
    }

    private void UpdatePollInterval(State? newState)
    {
        if (newState != null)
        {
            // TODO Still need to check if json also returns Spectator specific Navigationstates
            switch (newState.NavigationState)
            {
                case (HttpGameStates.PlayerInPits):
                    _pollInterval = TimeSpan.FromMilliseconds(500);
                    break;
                case (HttpGameStates.PlayerOnTrack):
                    _pollInterval = TimeSpan.FromMilliseconds(500);
                    break;
                default:
                    _pollInterval = TimeSpan.FromSeconds(1);
                    break;
            }
        }
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }
}