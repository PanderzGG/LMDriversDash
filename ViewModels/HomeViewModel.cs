using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    private readonly IGameDataService _gameDataService;

    // Properties for UI
    [ObservableProperty] private string _playerName = "!";
    [ObservableProperty] private string _httpGameState = "---";
    [ObservableProperty] private string _httpConnectionColor = "#fc0328";
    [ObservableProperty] private string _UdpConnectionColor = "#fc0328";
    
    // In Class attributes
    private bool httpIsConnected = false;
    private bool udpIsConnected = false;
    

    public HomeViewModel(IGameDataService gameDataService)
    {
        _gameDataService = gameDataService;
        PageName = ApplicationPageNames.Home;

        // Subscribe to Events
        _gameDataService.HttpProfileInfoReceived += OnPlayerProfileReceived;

        getPlayerName();
    }

    private void getPlayerName()
    {
        if (_gameDataService.HttpProfileInfo != null)
        {
            PlayerName = $"{_gameDataService.HttpProfileInfo.Name}!";    
        }
    }

    private void OnPlayerProfileReceived(object? sender, HttpProfileInfoReceivedEvent e)
    {
        if (!string.IsNullOrWhiteSpace(e.HttpProfileInfo.Name))
        {
            PlayerName = $"{e.HttpProfileInfo.Name}!";    
        }
    }
    
    public HomeViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}