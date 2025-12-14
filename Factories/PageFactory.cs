using System;
using LMDriversDash.UsefulData;
using LMDriversDash.ViewModels;

namespace LMDriversDash.Factories;

public class PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName) => factory.Invoke(pageName);
}