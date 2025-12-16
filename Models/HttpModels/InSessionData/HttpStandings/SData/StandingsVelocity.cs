using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SData;

public class StandingsVelocity
{
    [JsonPropertyName("velocity")]
    public double Velocity { get; set; }

    [JsonPropertyName("x")]
    public double X { get; set; }

    [JsonPropertyName("y")]
    public double Y { get; set; }

    [JsonPropertyName("z")]
    public double Z { get; set; }
}

