using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.SessionSetup.SSData;

public class SSDriver
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("nationality")]
    public string Nationality { get; set; }

    [JsonPropertyName("skill")]
    public string Skill { get; set; }
}

