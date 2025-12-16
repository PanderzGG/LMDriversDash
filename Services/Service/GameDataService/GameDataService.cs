using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Events.Udp_Events;
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
    
    // HTTP Events
    public event EventHandler<HttpGameStateChangedEvent> HttpGameStateChanged;
    public event EventHandler<HttpProfileInfoReceivedEvent> HttpProfileInfoReceived;
    public event EventHandler<bool> HttpConnection;
    public event EventHandler<bool> UdpConnection;
    
    // UDP Events
    public event EventHandler<TelemetryDataReceivedEvent>? UdpTelemetryDataReceived;
    public event EventHandler<ScoringDataReceivedEvent>? UdpScoringDataReceived;

    // Public Properties
    public LoadingStatus? LoadingStatus { get; private set; }
    
    public State? CurrentState { get; private set; }
    
    public HttpProfileInfo? HttpProfileInfo { get; private set; }
    
    // private attributes
    // Polling Interval for Http
    private TimeSpan _pollInterval = TimeSpan.FromSeconds(1);
    private bool isHttpConnected = false;
    private bool isUdpConnected = false;
    
    public GameDataService(IHttpClientService httpClientService, IUdpClientService udpClientService)
    {
        _httpClientService = httpClientService;
        _udpClientService = udpClientService;
    }
    
    public async Task RunOnStartupAsync()
    {
        // Subscribe to events on startup
        _udpClientService.TelemetryDataReceived += (s, d) =>
            UdpTelemetryDataReceived?.Invoke(this, new TelemetryDataReceivedEvent(d));
        _udpClientService.ScoringDataReceived += (s, d) =>
            UdpScoringDataReceived?.Invoke(this, new ScoringDataReceivedEvent(d));
        
        // HTTP GameState Polling
        _ = Task.Run(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        await PollGameState();
                    }
                    catch (Exception ex)
                    {
                        isHttpConnected = false;
                        Debug.WriteLine("==================================");
                        Debug.WriteLine("GameDataService::RunOnStartupAsync:: L59: Error: Can't get game state. Is the game running?");
                        Debug.WriteLine("==================================");
                        HttpConnection?.Invoke(this, isHttpConnected);
                    }
                    await Task.Delay(_pollInterval, _cancellationTokenSource.Token);
                }
            }, _cancellationTokenSource.Token
        );
    }

    private async Task PollGameState()
    {
        Debug.WriteLine("==================================");
        Debug.WriteLine("==================================");
        Debug.WriteLine("GameDataService::RunOnStartupAsync");
        Debug.WriteLine("Polling new State");
        Debug.WriteLine("==================================");
        Debug.WriteLine("==================================");
        // Get current GameState from HTTP
        var newState = new State();
        
        newState = await _httpClientService.GetHttpGameStateAsync();

        if (string.IsNullOrWhiteSpace(newState.NavigationState))
        {
            if (isHttpConnected)
            {
                isHttpConnected = false;
                HttpConnection?.Invoke(this, isHttpConnected);
            }
            return;
        }
        
        // Test for Changes
        var stateChanged = CurrentState?.NavigationState != newState?.NavigationState;
        var oldState = CurrentState;
        CurrentState = newState;

        if (stateChanged || oldState == null)
        {
            HttpGameStateChanged?.Invoke(this, new HttpGameStateChangedEvent(oldState, CurrentState));
            // If Client recieves a valid change fire valid connection
            if (!isHttpConnected)
            {
                isHttpConnected = true;
                HttpConnection?.Invoke(this, isHttpConnected);    
            }
            UpdatePollInterval(newState);
            
            // Handle Udp Client Runtime
            if (isHttpConnected)
            {
                switch (CurrentState.NavigationState)
                {
                    case HttpGameStates.PlayerInMainMenu:
                        if (_udpClientService.getIsRunning())
                        {
                            _udpClientService.Stop();
                            isUdpConnected = false;
                            UdpConnection?.Invoke(this, isUdpConnected);
                        }
                        break;
                    case HttpGameStates.PlayerOnTrack:
                        if (!_udpClientService.getIsRunning())
                        {
                            _ = _udpClientService.StartUpAsync();
                            isUdpConnected = true;
                            UdpConnection?.Invoke(this, isUdpConnected);
                        }
                        break;
                    case HttpGameStates.PlayerInPits:
                        if (!_udpClientService.getIsRunning())
                        {
                            _ = _udpClientService.StartUpAsync();
                            isUdpConnected = true;
                            UdpConnection?.Invoke(this, isUdpConnected);
                        }
                        break;
                }
            }
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

    public string getPlayerName()
    {
        if (string.IsNullOrWhiteSpace(HttpProfileInfo?.Name))
        {
            return "";
        }
        return HttpProfileInfo?.Name;
    }

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }
}