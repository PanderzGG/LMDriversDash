using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRRacePosition
{
    [JsonPropertyName("gapToFirstInClassLaps")]
    public int GapToFirstInClassLaps { get; set; }

    [JsonPropertyName("gapToFirstInClassTime")]
    public double GapToFirstInClassTime { get; set; }

    [JsonPropertyName("gapToLastInClassLaps")]
    public int GapToLastInClassLaps { get; set; }

    [JsonPropertyName("gapToLastInClassTime")]
    public double GapToLastInClassTime { get; set; }

    [JsonPropertyName("placeInClass")]
    public int PlaceInClass { get; set; }

    [JsonPropertyName("placeOverall")]
    public int PlaceOverall { get; set; }
}