using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.InSessionData.SessionSetup.SSData;

public class SSSelectedCar
{
    [JsonPropertyName("classes")]
    public List<string> Classes { get; set; }

    [JsonPropertyName("classesOverride")]
    public string ClassesOverride { get; set; }

    [JsonPropertyName("desc")]
    public string Desc { get; set; }

    [JsonPropertyName("dlcAppID")]
    public int DlcAppId { get; set; }

    [JsonPropertyName("drivers")]
    public List<SSDriver> Drivers { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("fullPathTree")]
    public string FullPathTree { get; set; }

    [JsonPropertyName("fullTeam")]
    public string FullTeam { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("isOwned")]
    public bool IsOwned { get; set; }

    [JsonPropertyName("liveryName")]
    public string LiveryName { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("premID")]
    public int PremId { get; set; }

    [JsonPropertyName("primaryVehFile")]
    public bool PrimaryVehFile { get; set; }

    [JsonPropertyName("sig")]
    public string Sig { get; set; }

    [JsonPropertyName("team")]
    public string Team { get; set; }

    [JsonPropertyName("teamFounded")]
    public string TeamFounded { get; set; }

    [JsonPropertyName("teamHeadquarters")]
    public string TeamHeadquarters { get; set; }

    [JsonPropertyName("vehFile")]
    public string VehFile { get; set; }

    [JsonPropertyName("vehicle")]
    public string Vehicle { get; set; }
}

