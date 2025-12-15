using System;
using LMDriversDash.Models.UdpModels;

namespace LMDriversDash.Services.Events.Udp_Events;

public class ScoringDataReceivedEvent : EventArgs
{
    public ScoringInfo? ScoringInfo { get; set; }

    public ScoringDataReceivedEvent(ScoringInfo? scoringInfo)
    {
        ScoringInfo = scoringInfo;
    }
}