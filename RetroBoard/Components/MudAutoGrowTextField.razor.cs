using Microsoft.AspNetCore.Components;

namespace RetroBoard.Components;

public partial class MudAutoGrowTextField : ComponentBase
{
    private int _rows;

    [Parameter]
    public string Value { get; set; }

    [Parameter]
    public bool Disabled { get; set; } = false;

    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    [Parameter]
    public string TextAreaId { get; set; }

    private async Task SetValueAsync(string value)
    {
        Value = value;
        await ValueChanged.InvokeAsync(value);
    }

    protected override void OnParametersSet()
    {
        _rows = Math.Max(Value.Count(c => c is '\n') + 1, 2);
    }
}