using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRWeatherForecast
{
    [JsonPropertyName("nodes")]
    public RRWeatherNodes Nodes { get; set; }
}