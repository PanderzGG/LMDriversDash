using System.Collections.Generic;
using System.Text.Json.Serialization;
using LMDriversDash.Models.HttpModels.InSessionData.SessionSetup.SSData;

namespace LMDriversDash.Models.HttpModels.InSessionData.SessionSetup.SSWrapper;

public class HttpSessionSetupData
{
    [JsonPropertyName("classesSelection")]
    public List<string> ClassesSelection { get; set; }

    [JsonPropertyName("fullGrid")]
    public bool FullGrid { get; set; }

    [JsonPropertyName("selectedCar")]
    public SSSelectedCar SelectedCar { get; set; }

    [JsonPropertyName("trackInfo")]
    public SSTrackInfo TrackInfo { get; set; }
}

