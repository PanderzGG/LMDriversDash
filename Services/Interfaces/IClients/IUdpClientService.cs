using System;
using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.UdpModels;

namespace LMDriversDash.Services.Interfaces.IClients;

public interface IUdpClientService
{
    event EventHandler<ScoringInfo>? ScoringDataReceived;
    event EventHandler<TelemetryInfo>? TelemetryDataReceived;
    
    Task StartUpAsync();
    void Stop();
    bool getIsRunning();

}