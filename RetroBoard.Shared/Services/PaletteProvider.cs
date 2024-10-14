using MudBlazor;

namespace RetroBoard.Shared.Services;

internal class PaletteProvider : IPaletteProvider
{
    public PaletteLight Theme { get; init; }

    public PaletteProvider(MudThemeProvider mudThemeProvider)
    {
        Theme = mudThemeProvider.Theme!.PaletteLight;
    }
}