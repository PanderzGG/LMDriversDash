using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class SelectedCar
{
    [JsonPropertyName("classes")]
    public string[] Classes { get; set; }
    
    [JsonPropertyName("desc")]
    public string Description { get; set; }
    
    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }
    
    [JsonPropertyName("number")]
    public string Number { get; set; }
    
    [JsonPropertyName("team")]
    public string Team { get; set; }
    
    [JsonPropertyName("vehicle")]
    public string Vehicle { get; set; }
    
    [JsonPropertyName("liveryName")]
    public string LiveryName { get; set; }
}