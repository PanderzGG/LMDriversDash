using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRFuelInfo
{
    [JsonPropertyName("currentBattery")]
    public double CurrentBattery { get; set; }

    [JsonPropertyName("currentFuel")]
    public double CurrentFuel { get; set; }

    [JsonPropertyName("currentVirtualEnergy")]
    public double CurrentVirtualEnergy { get; set; }

    [JsonPropertyName("maxBattery")]
    public double MaxBattery { get; set; }

    [JsonPropertyName("maxFuel")]
    public double MaxFuel { get; set; }

    [JsonPropertyName("maxVirtualEnergy")]
    public double MaxVirtualEnergy { get; set; }
}