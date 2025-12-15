using System;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;
using LMDriversDash.Services.Events;

namespace LMDriversDash.Services.Interfaces.IGameState;

public interface IGameDataService
{
    // Needed Events
    event EventHandler<HttpGameStateChangedEvent> HttpGameStateChanged;
    event EventHandler<HttpProfileInfoReceivedEvent> HttpProfileInfoReceived;
    event EventHandler<bool> HttpConnection;
    // Needed Properties
    LoadingStatus? LoadingStatus { get; set; }
    State? CurrentState { get; set; }
    HttpProfileInfo? HttpProfileInfo { get; set; }

    Task RunOnStartupAsync();
    void Stop();
}