using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRWeatherNodes
{
    [JsonPropertyName("Duration")]
    public List<int> Duration { get; set; }

    [JsonPropertyName("Humidity")]
    public List<int> Humidity { get; set; }

    [JsonPropertyName("RainChance")]
    public List<int> RainChance { get; set; }

    [JsonPropertyName("Sky")]
    public List<int> Sky { get; set; }

    [JsonPropertyName("StartTime")]
    public List<int> StartTime { get; set; }

    [JsonPropertyName("Temperature")]
    public List<int> Temperature { get; set; }

    [JsonPropertyName("WindDirection")]
    public List<int> WindDirection { get; set; }

    [JsonPropertyName("WindSpeed")]
    public List<int> WindSpeed { get; set; }
}