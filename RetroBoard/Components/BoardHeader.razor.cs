using Microsoft.AspNetCore.Components;

namespace RetroBoard.Components;

public partial class BoardHeader : ComponentBase
{
    [Parameter]
    public string BoardName { get; set; }
}