using System;
using LMDriversDash.Models.UdpModels;

namespace LMDriversDash.Services.Events.Udp_Events;

public class TelemetryDataReceivedEvent : EventArgs
{
    public TelemetryInfo? TelemetryInfo { get; set; }
    
    public TelemetryDataReceivedEvent(TelemetryInfo? telemetryInfo)
    {
        TelemetryInfo = telemetryInfo;
    }
}