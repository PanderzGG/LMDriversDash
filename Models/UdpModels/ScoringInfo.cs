using System.Collections.Generic;
using System.Text.Json.Serialization;
using LMDriversDash.Models.UdpVehicleModels;

namespace LMDriversDash.Models.UdpModels;

public class ScoringInfo
{
    [JsonPropertyName("Type")]
    public string? Type { get; set; } // "ScoringInfoV01"

    [JsonPropertyName("mTrackName")]
    public string? TrackName { get; set; }

    [JsonPropertyName("mNumVehicles")]
    public int NumberOfVehicles { get; set; }
    
    [JsonPropertyName("mPlayerName")]
    public string? PlayerName { get; set; }
    
    [JsonPropertyName("mSession")]
    public int Session { get; set; } // 0=TestDay, 1=Practice, etc.
    
    [JsonPropertyName("mGamePhase")]
    public int GamePhase { get; set; } // 0=Loading, 3=Green, 7=Finished, etc.

    // Wetter und Umwelt
    [JsonPropertyName("mAmbientTemp")]
    public float AmbientTemperature { get; set; }
    [JsonPropertyName("mTrackTemp")]
    public float TrackTemperature { get; set; }
    [JsonPropertyName("mRaining")]
    public float Raining { get; set; } // Rain intensity (0-1)

    // Main array with info of all players
    [JsonPropertyName("mVehicles")]
    public List<LmuVehicleInfo>? Vehicles { get; set; }
}