using System.Threading.Tasks;
using LMDriversDash.Models.HttpModels.GameState;
using LMDriversDash.Models.HttpModels.InfoModels;

namespace LMDriversDash.Services.Interfaces.IClients;

public interface IHttpClientService
{
    Task<State> GetHttpGameStateAsync();
    Task<HttpProfileInfo> GetHttpProfileInfoAsync();
}