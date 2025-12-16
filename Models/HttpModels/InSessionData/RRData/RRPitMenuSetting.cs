using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitMenuSetting
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("isUsed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsUsed { get; set; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Type { get; set; }
}