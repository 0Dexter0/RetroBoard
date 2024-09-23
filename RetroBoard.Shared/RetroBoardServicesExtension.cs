using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RetroBoard.Shared.Services;

namespace RetroBoard.Shared;

public static class RetroBoardServicesExtension
{
    public static void AddRetroBoardServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();

        serviceCollection.AddSingleton<RetroBoardService>();
        serviceCollection.AddScoped<ColumnRemoveNotificationService>();
    }
}