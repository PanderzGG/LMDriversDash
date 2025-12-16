using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData;

public class PitStopTimeEstimate
{
    [JsonPropertyName("damage")]
    public double Damage { get; set; }
    [JsonPropertyName("driverSwap")]
    public double DriverSwap { get; set; }
    [JsonPropertyName("fuel")]
    public double Fuel { get; set; }
    [JsonPropertyName("penalties")]
    public double Penalties { get; set; }
    [JsonPropertyName("tires")]
    public double Tires { get; set; }
    [JsonPropertyName("total")]
    public double Total { get; set; }
    [JsonPropertyName("ve")]
    public double Ve { get; set; }
    
}