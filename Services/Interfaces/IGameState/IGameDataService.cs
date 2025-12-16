using System;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Events.Udp_Events;

namespace LMDriversDash.Services.Interfaces.IGameState;

public interface IGameDataService
{
    // HTTP Events
    event EventHandler<HttpGameStateChangedEvent> HttpGameStateChanged;
    event EventHandler<HttpProfileInfoReceivedEvent> HttpProfileInfoReceived;
    event EventHandler<bool> HttpConnection;
    event EventHandler<bool> UdpConnection;
    
    // UDP Events
    event EventHandler<TelemetryDataReceivedEvent> UdpTelemetryDataReceived;
    event EventHandler<ScoringDataReceivedEvent> UdpScoringDataReceived;
    
    // Needed Properties
    LoadingStatus? LoadingStatus { get; }
    State? CurrentState { get; }
    HttpProfileInfo? HttpProfileInfo { get; }

    Task RunOnStartupAsync();
    void Stop();
    public string getPlayerName();
}