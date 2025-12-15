using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LMDriversDash.Factories;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private PageFactory _pageFactory;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(SessionPageIsActive))]
    [NotifyPropertyChangedFor(nameof(DrivePageIsactive))]
    private PageViewModel _currentPage;

    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool SessionPageIsActive => CurrentPage.PageName == ApplicationPageNames.Session;
    public bool DrivePageIsactive => CurrentPage.PageName == ApplicationPageNames.Drive;
    
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToHome();
    }

    public MainViewModel()
    {
        
    }
    
    [RelayCommand]
    private void GoToHome()
    {
        CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Home);
        NavigationPageChange();
    }

    private void NavigationPageChange()
    {
        Debug.WriteLine("ActiveOutput");
        Debug.WriteLine($"{CurrentPage.PageName}");
    }
}