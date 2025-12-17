using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LMDriversDash.Services.Events;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;
using SkiaSharp;

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
        
        
        // temporary Testdata for runtime

        #region TemporaryTest
            
        var test = new List<HomeGridTestData>
        {
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:00", "1", "Won", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:01", "2", "Podium", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:02", "3", "Podium", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:03", "4", "Top 5", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:04", "5", "Top 5", "\uE220  |   \uE20C")
        };
        gridtest = new ObservableCollection<HomeGridTestData>(test);

        #endregion
        
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
    
    
    // Design VM
    public HomeViewModel()
    {
        PageName = ApplicationPageNames.Home;

        // DataGrid Test Data
        var test = new List<HomeGridTestData>
        {
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:00", "1", "Won", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:01", "2", "Podium", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:02", "3", "Podium", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:03", "4", "Top 5", "\uE220  |   \uE20C"),
            new HomeGridTestData("01.01.2026", "Circuit de la Sarthe in France", "2:04", "5", "Top 5", "\uE220  |   \uE20C")
        };
        gridtest = new ObservableCollection<HomeGridTestData>(test);
    }
    
    // Pie Chart Test Data - Tracks
    public ISeries[] TrackSeries { get; set; } = new ISeries[]
    {
        new PieSeries<int>
        {
            Values = new int[] {50},
            Name = "Monza",
            Fill = new SolidColorPaint(SKColor.Parse("#78ef3f")),
            Stroke = null,
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 12
        },
        new PieSeries<int>
        {
            Values = new int[] {48},
            Name = "Spa",
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 200)),
            Stroke = null,
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 12
        },
        new PieSeries<int>
        {
            Values = new int[] {25},
            Name = "Le Mans",
            Stroke = null,
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 150)),
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 12
        },
        new PieSeries<int>
        {
            Values = new int[] {100},
            Name = "Rainbowroad",
            Stroke = null,
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 100)),
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 12
        },
    };
    
    // Pie Chart Test Data - Vehicles
    public ISeries[] VehicleSeries { get; set; } = new ISeries[]
    {
        new PieSeries<int>
        {
            Values = new int[] {65},
            Name = "Ferrari 499P",
            Fill = new SolidColorPaint(SKColor.Parse("#78ef3f")),
            Stroke = null,
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 11
        },
        new PieSeries<int>
        {
            Values = new int[] {52},
            Name = "Porsche 963",
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 210)),
            Stroke = null,
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 11
        },
        new PieSeries<int>
        {
            Values = new int[] {45},
            Name = "Oreca 07",
            Stroke = null,
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 170)),
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 11
        },
        new PieSeries<int>
        {
            Values = new int[] {38},
            Name = "BMW M4 GT3",
            Stroke = null,
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 130)),
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 11
        },
        new PieSeries<int>
        {
            Values = new int[] {30},
            Name = "Toyota GR010",
            Stroke = null,
            Fill = new SolidColorPaint(new SKColor(120, 239, 63, 90)),
            ShowDataLabels = true,
            DataLabelsPaint = new SolidColorPaint(SKColors.White),
            DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
            DataLabelsFormatter = point => point.Context.Series.Name,
            InnerRadius = 60,
            DataLabelsSize = 11
        },
    };
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