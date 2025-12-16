using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.SessionSetup.SSData;

public class SSTrackInfo
{
    [JsonPropertyName("cmpName")]
    public string CmpName { get; set; }

    [JsonPropertyName("corners")]
    public string Corners { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    [JsonPropertyName("defaultPracticeStartTime")]
    public int DefaultPracticeStartTime { get; set; }

    [JsonPropertyName("defaultPracticeWeather")]
    public List<SSWeatherNode> DefaultPracticeWeather { get; set; }

    [JsonPropertyName("defaultQualifyStartTime")]
    public int DefaultQualifyStartTime { get; set; }

    [JsonPropertyName("defaultQualifyWeather")]
    public List<SSWeatherNode> DefaultQualifyWeather { get; set; }

    [JsonPropertyName("defaultRaceLengthLaps")]
    public int DefaultRaceLengthLaps { get; set; }

    [JsonPropertyName("defaultRaceLengthTime")]
    public int DefaultRaceLengthTime { get; set; }

    [JsonPropertyName("defaultRaceStartTime")]
    public int DefaultRaceStartTime { get; set; }

    [JsonPropertyName("defaultRaceWeather")]
    public List<SSWeatherNode> DefaultRaceWeather { get; set; }

    [JsonPropertyName("dlcAppID")]
    public int DlcAppId { get; set; }

    [JsonPropertyName("eventName")]
    public string EventName { get; set; }

    [JsonPropertyName("grandPrixName")]
    public string GrandPrixName { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("isOwned")]
    public bool IsOwned { get; set; }

    [JsonPropertyName("layoutName")]
    public string LayoutName { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("officialEvent")]
    public bool OfficialEvent { get; set; }

    [JsonPropertyName("openingYear")]
    public string OpeningYear { get; set; }

    [JsonPropertyName("premId")]
    public int PremId { get; set; }

    [JsonPropertyName("properTrackName")]
    public string ProperTrackName { get; set; }

    [JsonPropertyName("sceneDesc")]
    public string SceneDesc { get; set; }

    [JsonPropertyName("sceneSig")]
    public string SceneSig { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonPropertyName("trackLength")]
    public string TrackLength { get; set; }

    [JsonPropertyName("trackName")]
    public string TrackName { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }
}

