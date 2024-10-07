using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using Colors = RetroBoard.Shared.Colors;

namespace RetroBoard.Layout;

public partial class MainLayout
{
    [Inject]
    private NavigationManager NavigationManager { get; init; }

    [Inject]
    private MudThemeProvider Provider { get; set; }

    private readonly MudTheme _theme = new();

    protected override void OnInitialized()
    {
        MudColor primary = new(Colors.Primary);
        MudColor secondary = new(Colors.Secondary);
        MudColor black = new(Colors.Black);

        _theme.PaletteLight.Primary = primary;
        _theme.PaletteLight.PrimaryDarken = new("#00CED1");
        _theme.PaletteLight.PrimaryLighten = new("#AFEEEE");

        _theme.PaletteLight.Secondary = new("#85bbb5");
        _theme.PaletteLight.SecondaryDarken = secondary.ColorRgbDarken().Value;
        _theme.PaletteLight.SecondaryLighten = secondary.ColorRgbLighten().Value;

        // _theme.PaletteLight.Background = new("#424242");
        _theme.PaletteLight.Background = _theme.PaletteLight.SecondaryDarken;
        _theme.PaletteLight.TextPrimary = black;
        _theme.PaletteLight.TextSecondary = new("#FFFFFF");
        _theme.PaletteLight.TextDisabled = new("#212121");

        Provider.Theme = _theme;
        StateHasChanged();
    }

    private void OnClick()
    {
        NavigationManager.NavigateTo(Environment.GetEnvironmentVariable("REDIRECT") ?? "/");
    }
}