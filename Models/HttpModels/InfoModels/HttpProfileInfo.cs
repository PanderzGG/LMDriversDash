using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InfoModels;

public class HttpProfileInfo
{
    [JsonPropertyName("language")]
    public string Language { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("nationality")]
    public string Nationality { get; set; }
    [JsonPropertyName("nick")]
    public string Nick { get; set; }
    [JsonPropertyName("steamID")]
    public string SteamID { get; set; }
}