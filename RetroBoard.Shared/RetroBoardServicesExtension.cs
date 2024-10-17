using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using RetroBoard.Shared.Services;

namespace RetroBoard.Shared;

public static class RetroBoardServicesExtension
{
    public static void AddRetroBoardServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            config.SnackbarConfiguration.ClearAfterNavigation = false;
        });

        serviceCollection.AddSingleton<IRetroBoardService, RetroBoardService>();
        serviceCollection.AddSingleton<IPaletteProvider, PaletteProvider>();
        serviceCollection.AddSingleton<MudThemeProvider>();
        serviceCollection.AddScoped<ColumnRemoveNotificationService>();
        serviceCollection.AddScoped<IUserService, UserService>();

        serviceCollection.AddBlazoredSessionStorageAsSingleton();
        serviceCollection.AddBlazoredLocalStorageAsSingleton();
    }
}