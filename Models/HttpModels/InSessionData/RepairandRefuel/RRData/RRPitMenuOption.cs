using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitMenuOption
{
    [JsonPropertyName("PMC Value")]
    public int PmcValue { get; set; }

    [JsonPropertyName("currentSetting")]
    public int CurrentSetting { get; set; }

    [JsonPropertyName("default")]
    public int Default { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("settings")]
    public List<RRPitMenuSetting> Settings { get; set; }
}