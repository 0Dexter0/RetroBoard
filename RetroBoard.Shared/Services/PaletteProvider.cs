using MudBlazor;

namespace RetroBoard.Shared.Services;

public class PaletteProvider
{
    public PaletteLight Theme { get; init; }

    public PaletteProvider(MudThemeProvider mudThemeProvider)
    {
        Theme = mudThemeProvider.Theme!.PaletteLight;
    }
}