using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class State
{
    [JsonPropertyName("appBuild")]
    public int AppBuild { get; set; }
    
    [JsonPropertyName("gamePhase")]
    public string GamePhase { get; set; }
    
    [JsonPropertyName("gameSession")]
    public string GameSession { get; set; }
    
    [JsonPropertyName("gameState")]
    public string GameState { get; set; }
    
    [JsonPropertyName("internalStateCode")]
    public string InternalStateCode { get; set; }
    
    // NavigationState is used to tell if in Menu or not.
    [JsonPropertyName("navigationState")]
    public string NavigationState { get; set; }
    
    [JsonPropertyName("settingMode")]
    public string SettingMode { get; set; }
    
    [JsonPropertyName("steamBetaBranchName")]
    public string SteamBetaBranchName { get; set; }
}