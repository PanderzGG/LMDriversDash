using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRSessionTime
{
    [JsonPropertyName("timeOfDay")]
    public double TimeOfDay { get; set; }
}