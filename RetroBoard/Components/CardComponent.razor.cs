using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Components;

public partial class CardComponent : ComponentBase
{
    private bool _isEditPressed = false;
    private bool _isEditButtonVisible = false;
    private bool _isSettingsPressed = false;
    private string _actionItemContent = string.Empty;
    private readonly string _actionTextAreaId = Guid.NewGuid().ToString();
    private IJSObjectReference _module;

    [Inject]
    public ColumnRemoveNotificationService NotificationService { get; init; }

    [Inject]
    public IRetroBoardService RetroBoardService { get; init; }

    [Inject]
    public PaletteProvider PaletteProvider { get; init; }

    [Parameter]
    public Card Card { get; init; }

    [Parameter]
    public Func<Card, Task> RemoveCardAsync { get; set; }

    public string Title { get; protected set; }

    public string Content { get; protected set; }

    protected override void OnParametersSet()
    {
        Title = Card.Title;
        Content = Card.Content;
    }

    private async Task SaveAsync()
    {
        Card.Title = Title;
        Card.Content = Content;
        _isEditPressed = false;
        _isEditButtonVisible = false;

        // await NotificationService.NotifyAsync("");
    }

    private void Discard()
    {
        Title = Card.Title;
        Content = Card.Content;
        _isEditPressed = false;
        _isEditButtonVisible = false;
    }

    private void CreateActionItem()
    {
        Card.ActionItems.Add(new() { Content = _actionItemContent.Trim() });
        _actionItemContent = string.Empty;
    }

    private void OnToggle(bool toggle)
    {
        if (toggle)
        {
            Card.Like++;
        }
        else
        {
            Card.Like--;
        }
    }
}
