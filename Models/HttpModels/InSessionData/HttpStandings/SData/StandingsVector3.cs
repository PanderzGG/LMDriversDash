using System.Text.Json.Serialization;
   
namespace LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SData;
public class StandingsVector3
{
    [JsonPropertyName("z")]
    public double Z { get; set; }
    [JsonPropertyName("y")]
    public double Y { get; set; }
    [JsonPropertyName("x")]
    public double X { get; set; }
    [JsonPropertyName("type")]
    public int Type { get; set; }
    
}



