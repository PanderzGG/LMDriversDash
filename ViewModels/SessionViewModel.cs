using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public class SessionViewModel : PageViewModel
{
    private readonly IGameDataService _gameDataService;

    public SessionViewModel(IGameDataService gameDataService)
    {
        _gameDataService = gameDataService;
        PageName = ApplicationPageNames.Session;
    }

    public SessionViewModel()
    {
        PageName = ApplicationPageNames.Session;
    }
}