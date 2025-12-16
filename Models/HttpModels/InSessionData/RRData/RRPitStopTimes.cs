using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitStopTimes
{
    [JsonPropertyName("times")]
    public Dictionary<string, object> Times { get; set; }
}