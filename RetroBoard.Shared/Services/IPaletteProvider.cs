using MudBlazor;

namespace RetroBoard.Shared.Services;

public interface IPaletteProvider
{
    PaletteLight Theme { get; init; }
}