using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Components;

public partial class ColumnComponent : ComponentBase
{
    private bool _isEditPressed = false;
    private bool _isCardCreatePressed = false;
    private string _cardTitle = string.Empty;
    private string _cardContent = string.Empty;
    private string _columnName = string.Empty;
    private bool _isEditButtonVisible = false;

    [Inject]
    private IRetroBoardService RetroBoardService { get; set; }

    [Inject]
    private ColumnRemoveNotificationService NotificationService { get; set; }

    [Parameter]
    public Column Column { get; set; }

    protected override void OnParametersSet()
    {
        _columnName = Column.Name;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Column.Cards.Any())
        {
            await NotificationService.NotifyAsync();
        }
    }

    private void CreateCard()
    {
        _isCardCreatePressed = false;

        Column.Cards.Add(new() { ColumnId = Column.Id.ToString(), Title = _cardTitle, Content = _cardContent });
        _cardTitle = String.Empty;
        _cardContent = String.Empty;
    }

    private async Task RemoveColumnAsync(MouseEventArgs obj)
    {
        RetroBoardService.GetBoards().Single(x => x.Id == Column.BoardId).Columns.Remove(Column);
        await NotificationService.NotifyAsync();
    }

    private async Task RemoveCardAsync(Card card)
    {
        Column.Cards.Remove(card);
        await NotificationService.NotifyAsync();
    }

    private async Task SaveAsync()
    {
        Column.Name = _columnName;
        _isEditPressed = false;
        _isEditButtonVisible = false;

        await NotificationService.NotifyAsync();
    }

    private void Discard()
    {
        _columnName = Column.Name;
        _isEditPressed = false;
        _isEditButtonVisible = false;
    }
}