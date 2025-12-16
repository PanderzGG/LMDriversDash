using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SData;

public class StandingsAttackMode
{
    [JsonPropertyName("remainingCount")]
    public int RemainingCount { get; set; }

    [JsonPropertyName("timeRemaining")]
    public int TimeRemaining { get; set; }

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
}

