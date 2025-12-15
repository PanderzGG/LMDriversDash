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
        _gameDataService.HttpGameStateChanged += OnGameStateChanged;
        _gameDataService.HttpProfileInfoReceived += OnPlayerProfileReceived;
        _gameDataService.HttpConnection += OnHttpConnectionStatus;
        _gameDataService.UdpConnection += OnUdpConnectionStatus;

        CheckForHttpInfo();
    }

    private void OnUdpConnectionStatus(object? sender, bool e)
    {
        udpIsConnected = e;
        CheckForUdpInfo();
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
        switch (httpIsConnected)
        {
            case true:
                HttpConnectionColor = "#4CAF50"; // Green
                break;
            case false:
                HttpConnectionColor = "#fc0328"; // Red
                HttpGameState = "---";
                break;
        }
    }
    private void CheckForUdpInfo()
    {
        switch (udpIsConnected)
        {
            case true:
                UdpConnectionColor = "#4CAF50"; // Green
                break;
            case false:
                UdpConnectionColor = "#fc0328"; // Red
                break;
        }
    }
    
    public HomeViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}