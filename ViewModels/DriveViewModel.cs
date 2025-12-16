using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public class DriveViewModel : PageViewModel
{
    private readonly IGameDataService _gameDataService;

    public DriveViewModel(IGameDataService gameDataService)
    {
        _gameDataService = gameDataService;
        PageName = ApplicationPageNames.Drive;
    }

    public DriveViewModel()
    {
        PageName = ApplicationPageNames.Drive;
    }
    
}