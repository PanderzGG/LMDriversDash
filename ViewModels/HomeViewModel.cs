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
    [ObservableProperty] private string _connectionColor;
    
    // In Class attributes
    private bool httpIsConnected = false;
    

    public HomeViewModel(IGameDataService gameDataService)
    {
        _gameDataService = gameDataService;
        PageName = ApplicationPageNames.Home;

        // Subscribe to Events
        _gameDataService.HttpGameStateChanged += OnGameStateChanged;
        _gameDataService.HttpProfileInfoReceived += OnPlayerProfileReceived;
        _gameDataService.HttpConnection += OnHttpConnectionLost;

        CheckForHttpInfo(httpIsConnected);
    }

    private void OnHttpConnectionLost(object? sender, bool e)
    {
        httpIsConnected = false;
    }

    private void OnPlayerProfileReceived(object? sender, HttpProfileInfoReceivedEvent e)
    {
        if (!string.IsNullOrWhiteSpace(e.HttpProfileInfo.Name))
        {
            PlayerName = $"{e.HttpProfileInfo.Name}!";    
        }
        CheckForHttpInfo(httpIsConnected);
    }

    private void OnGameStateChanged(object? sender, HttpGameStateChangedEvent e)
    {
        Debug.WriteLine($"Game state changed to {e.NewState?.NavigationState}");
    }

    private void CheckForHttpInfo(bool isConnected)
    {
        // TODO Maybe get rid of magic strings an put the colors into a resource or something idk
        if (PlayerName != "!")
        {
            httpIsConnected = true;
            ConnectionColor = "#4CAF50"; // Green

        }
        else
        {
            httpIsConnected = false;
            ConnectionColor = "#fc0328"; // Red
        }
    }
    
    public HomeViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}