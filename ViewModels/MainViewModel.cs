using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LMDriversDash.Factories;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IGameDataService _gameDataService;
    
    private PageFactory _pageFactory;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(SessionPageIsActive))]
    [NotifyPropertyChangedFor(nameof(DrivePageIsactive))]
    private PageViewModel _currentPage;
    
    [ObservableProperty] private string _httpGameState = "---";
    [ObservableProperty] private string _httpConnectionColor = "#fc0328";
    [ObservableProperty] private string _udpConnectionColor = "#fc0328";
    
    
    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool SessionPageIsActive => CurrentPage.PageName == ApplicationPageNames.Session;
    public bool DrivePageIsactive => CurrentPage.PageName == ApplicationPageNames.Drive;
    
    public MainViewModel()
    {
        
    }
    
    public MainViewModel(PageFactory pageFactory, IGameDataService gameDataService)
    {
        _pageFactory = pageFactory;
        _gameDataService = gameDataService;

        _gameDataService.HttpConnection += OnHttpConnectionStatus;
        _gameDataService.UdpConnection += OnUdpConnectionStatus;
        _gameDataService.HttpGameStateChanged += OnGameStateChanged;
        
        GoToHome();
    }

    private void OnGameStateChanged(object? sender, HttpGameStateChangedEvent e)
    {
        HttpGameState = e.NewState.NavigationState;
    }

    private void OnUdpConnectionStatus(object? sender, bool e)
    {
        CheckForConnectionStatus("udp", e);
    }

    private void OnHttpConnectionStatus(object? sender, bool e)
    {
        CheckForConnectionStatus("http", e);
    }

    private void CheckForConnectionStatus(string type, bool status)
    {
        switch (status)
        {
            case true:
                if (type == "http")
                {
                    HttpConnectionColor = "#4CAF50"; // Green
                }
                else
                {
                    UdpConnectionColor = "#4CAF50"; // Green
                }
                break;
            case false:
                if (type == "http")
                {
                    HttpConnectionColor = "#fc0328"; // Red
                    HttpGameState = "---";
                }
                else
                {
                    UdpConnectionColor = "#fc0328"; // Red
                }
                break;
        }
    }
    
    [RelayCommand]
    private void GoToHome()
    {
        CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Home);
        NavigationPageChange();
    }

    [RelayCommand]
    private void GoToSession()
    {
        CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Session);
        NavigationPageChange();
    }

    [RelayCommand]
    private void GoToDrive()
    {
        CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Drive);
        NavigationPageChange();
    }
    
    private void NavigationPageChange()
    {
        Debug.WriteLine("ActiveOutput");
        Debug.WriteLine($"{CurrentPage.PageName}");
    }
}