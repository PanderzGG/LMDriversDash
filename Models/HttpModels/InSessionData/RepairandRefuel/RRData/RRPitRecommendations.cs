using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitRecommendations
{
    [JsonPropertyName("FL TIRE:")]
    public int FlTire { get; set; }

    [JsonPropertyName("FR TIRE:")]
    public int FrTire { get; set; }

    [JsonPropertyName("RL TIRE:")]
    public int RlTire { get; set; }

    [JsonPropertyName("RR TIRE:")]
    public int RrTire { get; set; }

    [JsonPropertyName("TIRES:")]
    public int Tires { get; set; }

    [JsonPropertyName("fuel")]
    public int Fuel { get; set; }

    [JsonPropertyName("virtualEnergy")]
    public int VirtualEnergy { get; set; }
}