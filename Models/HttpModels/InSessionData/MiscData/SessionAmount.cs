using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData;

public class SessionAmount
{
    [JsonPropertyName("PRACTICE")]
    public int Practice { get; set; }
    [JsonPropertyName("QUALIFY")]
    public int Qualify { get; set; }
    [JsonPropertyName("RACE")]
    public int Race { get; set; }
    [JsonPropertyName("WARMUP")]
    public int Warmup { get; set; }
}