using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRBody
{
    [JsonPropertyName("aero")]
    public double Aero { get; set; }

    [JsonPropertyName("detachableParts")]
    public List<bool> DetachableParts { get; set; }
}