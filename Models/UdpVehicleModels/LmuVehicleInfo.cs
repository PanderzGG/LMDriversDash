using System.Text.Json.Serialization;

namespace LMDriversDash.Models.UdpVehicleModels;

public class LmuVehicleInfo
{
    // Base information
    [JsonPropertyName("mID")]
    public int Id { get; set; }

    [JsonPropertyName("mDriverName")]
    public string? DriverName { get; set; }

    [JsonPropertyName("mVehicleName")]
    public string? VehicleName { get; set; }

    [JsonPropertyName("mIsPlayer")]
    public bool IsPlayer { get; set; }

    [JsonPropertyName("mPlace")]
    public int Place { get; set; }

    [JsonPropertyName("mControl")]
    public int Control { get; set; } // 0=AI, 1=Player/Remote

    // Laps and Timings
    [JsonPropertyName("mTotalLaps")]
    public int TotalLaps { get; set; }
    
    [JsonPropertyName("mLapDist")]
    public float LapDistance { get; set; } // Distance Start/Finish

    [JsonPropertyName("mSector")]
    public int Sector { get; set; } // Current Sector (0, 1, 2)

    [JsonPropertyName("mTimeBehindLeader")]
    public float TimeBehindLeader { get; set; }

    [JsonPropertyName("mTimeBehindNext")]
    public float TimeBehindNext { get; set; }

    [JsonPropertyName("mBestLapTime")]
    public float BestLapTime { get; set; }

    [JsonPropertyName("mEstimatedLapTime")]
    public float EstimatedLapTime { get; set; }

    // Pit information
    private bool _inPits;
    [JsonPropertyName("mInPits")]
    public bool InPits { get; set; }

    [JsonPropertyName("mPitState")]
    public int PitState { get; set; } // 0=None, 1=Request, 2=Entered, 3=Stopped, 4=Exiting, 5=Delayed

    // Physics information float[3] arrays
    [JsonPropertyName("mPos")]
    public float[]? Position { get; set; } // [x, y, z]

    [JsonPropertyName("mLocalAccel")]
    public float[]? LocalAcceleration { get; set; } // [x, y, z]
}