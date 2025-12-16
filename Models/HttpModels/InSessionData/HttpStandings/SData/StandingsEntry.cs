using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.HttpStandings.SData;

public class StandingsEntry
{
    [JsonPropertyName("attackMode")]
    public StandingsAttackMode AttackMode { get; set; }

    [JsonPropertyName("bestLapSectorTime1")]
    public double BestLapSectorTime1 { get; set; }

    [JsonPropertyName("bestLapSectorTime2")]
    public double BestLapSectorTime2 { get; set; }

    [JsonPropertyName("bestLapTime")]
    public double BestLapTime { get; set; }

    [JsonPropertyName("bestSectorTime1")]
    public double BestSectorTime1 { get; set; }

    [JsonPropertyName("bestSectorTime2")]
    public double BestSectorTime2 { get; set; }

    [JsonPropertyName("carAcceleration")]
    public StandingsVelocity CarAcceleration { get; set; }

    [JsonPropertyName("carClass")]
    public string CarClass { get; set; }

    [JsonPropertyName("carId")]
    public string CarId { get; set; }

    [JsonPropertyName("carNumber")]
    public string CarNumber { get; set; }

    [JsonPropertyName("carPosition")]
    public StandingsVector3 CarPosition { get; set; }

    [JsonPropertyName("carVelocity")]
    public StandingsVelocity CarVelocity { get; set; }

    [JsonPropertyName("countLapFlag")]
    public string CountLapFlag { get; set; }

    [JsonPropertyName("currentSectorTime1")]
    public double CurrentSectorTime1 { get; set; }

    [JsonPropertyName("currentSectorTime2")]
    public double CurrentSectorTime2 { get; set; }

    [JsonPropertyName("driverName")]
    public string DriverName { get; set; }

    [JsonPropertyName("drsActive")]
    public bool DrsActive { get; set; }

    [JsonPropertyName("estimatedLapTime")]
    public double EstimatedLapTime { get; set; }

    [JsonPropertyName("finishStatus")]
    public string FinishStatus { get; set; }

    [JsonPropertyName("flag")]
    public string Flag { get; set; }

    [JsonPropertyName("focus")]
    public bool Focus { get; set; }

    [JsonPropertyName("fuelFraction")]
    public double FuelFraction { get; set; }

    [JsonPropertyName("fullTeamName")]
    public string FullTeamName { get; set; }

    [JsonPropertyName("gamePhase")]
    public string GamePhase { get; set; }

    [JsonPropertyName("hasFocus")]
    public bool HasFocus { get; set; }

    [JsonPropertyName("headlights")]
    public bool Headlights { get; set; }

    [JsonPropertyName("inControl")]
    public int InControl { get; set; }

    [JsonPropertyName("inGarageStall")]
    public bool InGarageStall { get; set; }

    [JsonPropertyName("lapDistance")]
    public double LapDistance { get; set; }

    [JsonPropertyName("lapStartET")]
    public double LapStartET { get; set; }

    [JsonPropertyName("lapsBehindLeader")]
    public int LapsBehindLeader { get; set; }

    [JsonPropertyName("lapsBehindNext")]
    public int LapsBehindNext { get; set; }

    [JsonPropertyName("lapsCompleted")]
    public int LapsCompleted { get; set; }

    [JsonPropertyName("lastLapTime")]
    public double LastLapTime { get; set; }

    [JsonPropertyName("lastSectorTime1")]
    public double LastSectorTime1 { get; set; }

    [JsonPropertyName("lastSectorTime2")]
    public double LastSectorTime2 { get; set; }

    [JsonPropertyName("pathLateral")]
    public double PathLateral { get; set; }

    [JsonPropertyName("penalties")]
    public int Penalties { get; set; }

    [JsonPropertyName("pitGroup")]
    public string PitGroup { get; set; }

    [JsonPropertyName("pitLapDistance")]
    public double PitLapDistance { get; set; }

    [JsonPropertyName("pitState")]
    public string PitState { get; set; }

    [JsonPropertyName("pitstops")]
    public int Pitstops { get; set; }

    [JsonPropertyName("pitting")]
    public bool Pitting { get; set; }

    [JsonPropertyName("player")]
    public bool Player { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("qualification")]
    public int Qualification { get; set; }

    [JsonPropertyName("sector")]
    public string Sector { get; set; }

    [JsonPropertyName("serverScored")]
    public bool ServerScored { get; set; }

    [JsonPropertyName("slotID")]
    public int SlotId { get; set; }

    [JsonPropertyName("steamID")]
    public ulong SteamId { get; set; }

    [JsonPropertyName("timeBehindLeader")]
    public double TimeBehindLeader { get; set; }

    [JsonPropertyName("timeBehindNext")]
    public double TimeBehindNext { get; set; }

    [JsonPropertyName("timeIntoLap")]
    public double TimeIntoLap { get; set; }

    [JsonPropertyName("trackEdge")]
    public double TrackEdge { get; set; }

    [JsonPropertyName("underYellow")]
    public bool UnderYellow { get; set; }

    [JsonPropertyName("upgradePack")]
    public string UpgradePack { get; set; }

    [JsonPropertyName("vehicleFilename")]
    public string VehicleFilename { get; set; }

    [JsonPropertyName("vehicleName")]
    public string VehicleName { get; set; }
}

