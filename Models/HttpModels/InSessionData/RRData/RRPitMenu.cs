using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRPitMenu
{
    [JsonPropertyName("pitMenu")]
    public List<RRPitMenuOption> PitMenuOptions { get; set; }
}