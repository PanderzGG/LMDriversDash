using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRWearables
{
    [JsonPropertyName("body")]
    public RRBody Body { get; set; }

    [JsonPropertyName("brakes")]
    public List<double> Brakes { get; set; }

    [JsonPropertyName("suspension")]
    public List<double> Suspension { get; set; }

    [JsonPropertyName("tires")]
    public List<double> Tires { get; set; }
}