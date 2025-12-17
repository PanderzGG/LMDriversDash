using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    // TestData for UI Mockup
    public ObservableCollection<HomeGridTestData> gridtest { get; }
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
        var test = new List<HomeGridTestData>
        {
            new HomeGridTestData("01.01.2026","Spa","2:00","1","Won","x, x"),
            new HomeGridTestData("01.01.2026","Spa","2:01","2","Podium","x, x"),
            new HomeGridTestData("01.01.2026","Spa","2:02","3","Podium","x, x"),
            new HomeGridTestData("01.01.2026","Spa","2:03","4","Top 5","x, x"),
            new HomeGridTestData("01.01.2026","Spa","2:04","5","Top 5","x, x")
        };
        gridtest = new ObservableCollection<HomeGridTestData>(test);
    }
}

public class HomeGridTestData
{
    public string? Date { get; set;}
    public string? Track { get; set;}
    public string? BestLap { get; set;}
    public string? Position { get; set;}
    public string? Status { get; set;}
    public string? Actions { get; set;}

    public HomeGridTestData(string date, string track, string bestLap, string position, string status, string actions)
    {
        Date = date;
        Track = track;
        BestLap = bestLap;
        Position = position;
        Status = status;
        Actions = actions;
    }
}