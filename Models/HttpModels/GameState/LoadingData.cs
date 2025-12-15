using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class LoadingData
{
    [JsonPropertyName("selectedCar")]
    public SelectedCar SelectedCar { get; set; }
    
    [JsonPropertyName("trackInfo")]
    public TrackInfo TrackInfo { get; set; }
}