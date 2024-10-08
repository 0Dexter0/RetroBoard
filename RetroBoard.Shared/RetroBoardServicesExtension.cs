﻿using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using RetroBoard.Shared.Services;

namespace RetroBoard.Shared;

public static class RetroBoardServicesExtension
{
    public static void AddRetroBoardServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();

        serviceCollection.AddSingleton<IRetroBoardService, RetroBoardService>();
        serviceCollection.AddSingleton<PaletteProvider>();
        serviceCollection.AddSingleton<MudThemeProvider>();
        serviceCollection.AddScoped<ColumnRemoveNotificationService>();
        serviceCollection.AddBlazoredSessionStorageAsSingleton();
        // serviceCollection.AddBlazoredSessionStorage();
    }
}