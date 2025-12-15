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
        _gameDataService.HttpConnection += OnHttpConnectionStatus;

        CheckForHttpInfo();
    }

    private void OnHttpConnectionStatus(object? sender, bool e)
    {
        httpIsConnected = e;
        CheckForHttpInfo();
    }

    private void OnPlayerProfileReceived(object? sender, HttpProfileInfoReceivedEvent e)
    {
        if (!string.IsNullOrWhiteSpace(e.HttpProfileInfo.Name))
        {
            PlayerName = $"{e.HttpProfileInfo.Name}!";    
        }
        CheckForHttpInfo();
    }

    private void OnGameStateChanged(object? sender, HttpGameStateChangedEvent e)
    {
        HttpGameState = e.NewState.NavigationState;
    }

    private void CheckForHttpInfo()
    {
        // TODO Maybe get rid of magic strings an put the colors into a resource or something idk
        if (httpIsConnected)
        {
            httpIsConnected = true;
            ConnectionColor = "#4CAF50"; // Green

        }
        else
        {
            httpIsConnected = false;
            ConnectionColor = "#fc0328"; // Red
            HttpGameState = "---";
        }
    }
    
    public HomeViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}