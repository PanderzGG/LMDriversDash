using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class TrackInfo
{
    [JsonPropertyName("trackName")]
    public string TrackName { get; set; }
    
    [JsonPropertyName("trackLength")]
    public string TrackLength { get; set; }
    
    [JsonPropertyName("location")]
    public string Location { get; set; }
    
    [JsonPropertyName("corners")]
    public string Corners { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
}