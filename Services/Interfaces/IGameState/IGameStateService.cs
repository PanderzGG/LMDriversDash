using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;

namespace LMDriversDash.Services.Interfaces.IGameState;

public interface IGameStateService
{
    // Needed Properties
    LoadingStatus? LoadingStatus { get; set; }
    State? CurrentState { get; set; }
    HttpProfileInfo? HttpProfileInfo { get; set; }

    Task RunOnStartupAsync();
    void Stop();
}