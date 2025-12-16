using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class RRTeamInfo
{
    [JsonPropertyName("driverNames")]
    public List<List<int>> DriverNames { get; set; }

    [JsonPropertyName("teamName")]
    public string TeamName { get; set; }

    [JsonPropertyName("vehicleName")]
    public string VehicleName { get; set; }
}