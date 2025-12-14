using System.Text.Json.Serialization;

namespace LMDriversDash.Models.UdpModels;

public class TelemetryInfo
{
    [JsonPropertyName("Type")]
    public string? Type { get; set; } // "TelemInfoV01"

    [JsonPropertyName("mElapsedTime")]
    public double ElapsedTime { get; set; }

    [JsonPropertyName("mDeltaTime")]
    public double DeltaTime { get; set; } // Frame-Zeit in Sekunden

    [JsonPropertyName("mTrackName")]
    public string? TrackName { get; set; }
    
    [JsonPropertyName("mVehicleName")]
    public string? VehicleName { get; set; }
    
    // Fahrzeug-Status
    [JsonPropertyName("mGear")]
    public int Gear { get; set; }
    [JsonPropertyName("mEngineRPM")]
    public float EngineRPM { get; set; }
    [JsonPropertyName("mEngineMaxRPM")]
    public float EngineMaxRPM { get; set; }
    [JsonPropertyName("mFuel")]
    public float Fuel { get; set; }
    [JsonPropertyName("mFuelCapacity")]
    public float FuelCapacity { get; set; }
    [JsonPropertyName("mBatteryChargeFraction")]
    public float BatteryChargeFraction { get; set; }
    [JsonPropertyName("mSpeedLimiter")]
    public int SpeedLimiter { get; set; } // 0=off, 1=on

    // Fahrereingaben (gefiltert)
    [JsonPropertyName("mFilteredThrottle")]
    public float FilteredThrottle { get; set; }
    [JsonPropertyName("mFilteredBrake")]
    public float FilteredBrake { get; set; }
    [JsonPropertyName("mFilteredClutch")]
    public float FilteredClutch { get; set; }
    [JsonPropertyName("mFilteredSteering")]
    public float FilteredSteering { get; set; }
    
    // Temperaturen
    [JsonPropertyName("mEngineWaterTemp")]
    public float EngineWaterTemp { get; set; }
    [JsonPropertyName("mEngineOilTemp")]
    public float EngineOilTemp { get; set; }
    
    // Position und Physik (als verschachtelte Objekte)
    [JsonPropertyName("mPos")]
    public LmuVector3? Position { get; set; }
    [JsonPropertyName("mLocalAccel")]
    public LmuVector3? LocalAcceleration { get; set; }
    [JsonPropertyName("mLocalVel")]
    public LmuVector3? LocalVelocity { get; set; }
    
    // Rad-Informationen
    [JsonPropertyName("mWheel")]
    public LmuWheel[]? Wheel { get; set; }
    
    // Reifen-Informationen
    [JsonPropertyName("mFrontTireCompoundName")]
    public string? FrontTireCompoundName { get; set; }
    [JsonPropertyName("mRearTireCompoundName")]
    public string? RearTireCompoundName { get; set; }
}