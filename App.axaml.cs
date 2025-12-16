using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using Avalonia.Markup.Xaml;
using LMDriversDash.Factories;
using LMDriversDash.Services.Interfaces.IClients;
using LMDriversDash.Services.Interfaces.IGameState;
using LMDriversDash.Services.Service.Clients;
using LMDriversDash.Services.Service.GameState;
using LMDriversDash.UsefulData;
using LMDriversDash.ViewModels;
using LMDriversDash.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LMDriversDash;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DataTemplates.Add(new ViewLocator());
    }

    public override void OnFrameworkInitializationCompleted()
    {

        var collection = new ServiceCollection();
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<SessionViewModel>();
        collection.AddTransient<DriveViewModel>();
        
        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(x => name => name switch
        {
            ApplicationPageNames.Home => x.GetRequiredService<HomeViewModel>(),
            ApplicationPageNames.Session => x.GetRequiredService<SessionViewModel>(),
            ApplicationPageNames.Drive => x.GetRequiredService<DriveViewModel>(),
            _ => throw new ArgumentException("Unknown page", nameof(name))
        });

        collection.AddSingleton<PageFactory>();
        collection.AddSingleton<IHttpClientService, HttpClientService>();
        collection.AddSingleton<IUdpClientService, UdpClientService>();
        collection.AddSingleton<IGameDataService, GameDataService>();
        
        var serviceProvider = collection.BuildServiceProvider();
        
        var gameStateService = serviceProvider.GetRequiredService<IGameDataService>();
        var httpClientService = serviceProvider.GetRequiredService<IHttpClientService>();
        var udpClientService = serviceProvider.GetRequiredService<IUdpClientService>();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainView
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>(),
            };
            
            desktop.ShutdownRequested += (s, e) =>
            {
                gameStateService.Stop();
            };
        }

        base.OnFrameworkInitializationCompleted();
        // Start of Gamestate retrieval
        gameStateService.RunOnStartupAsync();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}