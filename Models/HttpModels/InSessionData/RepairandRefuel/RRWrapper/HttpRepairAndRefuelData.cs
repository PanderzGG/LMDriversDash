using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class HttpRepairAndRefuelData
{
    [JsonPropertyName("currentWeather")]
    public RRCurrentWeather CurrentWeather { get; set; }

    [JsonPropertyName("fuelInfo")]
    public RRFuelInfo FuelInfo { get; set; }

    [JsonPropertyName("pitMenu")]
    public RRPitMenu PitMenu { get; set; }

    [JsonPropertyName("pitRecommendations")]
    public RRPitRecommendations PitRecommendations { get; set; }

    [JsonPropertyName("pitStopLength")]
    public RRPitStopLength PitStopLength { get; set; }

    [JsonPropertyName("pitStopTimes")]
    public RRPitStopTimes PitStopTimes { get; set; }

    [JsonPropertyName("racePosition")]
    public RRRacePosition RacePosition { get; set; }

    [JsonPropertyName("sessionTime")]
    public RRSessionTime SessionTime { get; set; }

    [JsonPropertyName("teamInfo")]
    public RRTeamInfo TeamInfo { get; set; }

    [JsonPropertyName("wearables")]
    public RRWearables Wearables { get; set; }

    [JsonPropertyName("weatherForecast")]
    public RRWeatherForecast WeatherForecast { get; set; }
}






