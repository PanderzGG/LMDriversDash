using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class GameStateResponse
{
    [JsonPropertyName("loadingStatus")]
    public LoadingStatus loadingStatus { get; set; }
    
    [JsonPropertyName("state")]
    public State state { get; set; }
}