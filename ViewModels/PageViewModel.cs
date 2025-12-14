using CommunityToolkit.Mvvm.ComponentModel;
using LMDriversDash.UsefulData;

namespace LMDriversDash.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}