using System.Text.Json;
using System.Text.Json.Serialization;

namespace LMDriversDash.Models.HttpModels.GameState;

public class LoadingStatus
{
    [JsonPropertyName("loading")]
    public bool Loading { get; set; }
    
    [JsonPropertyName("loadingData")]
    public string LoadingDataRaw { get; set; }
    
    [JsonPropertyName("percentage")]
    public double Percentage { get; set; }


    [JsonIgnore]
    public LoadingData LoadingData
    {
        get
        {
            if (string.IsNullOrWhiteSpace(LoadingDataRaw))
                return null;
            
            return JsonSerializer.Deserialize<LoadingData>(LoadingDataRaw);
        }
    }
}