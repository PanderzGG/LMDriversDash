using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitStopLength
{
    [JsonPropertyName("timeInSeconds")]
    public double TimeInSeconds { get; set; }
}