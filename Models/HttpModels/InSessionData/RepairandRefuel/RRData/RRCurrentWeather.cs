using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRCurrentWeather
{
    [JsonPropertyName("airPressure")]
    public double AirPressure { get; set; }

    [JsonPropertyName("ambientTempKelvin")]
    public double AmbientTempKelvin { get; set; }

    [JsonPropertyName("cloudCoverage")]
    public double CloudCoverage { get; set; }

    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }

    [JsonPropertyName("lightLevel")]
    public double LightLevel { get; set; }

    [JsonPropertyName("rainIntensity")]
    public double RainIntensity { get; set; }

    [JsonPropertyName("raining")]
    public double Raining { get; set; }

    [JsonPropertyName("trackTempKelvin")]
    public double TrackTempKelvin { get; set; }
}