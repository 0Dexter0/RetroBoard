using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Components;

public partial class ColumnComponent : ComponentBase
{
    private bool _isOverlayEnabled = true;
    private bool _isCardCreatePressed = false;
    private string _cardTitle = String.Empty;
    private string _cardContent = String.Empty;

    [Inject]
    private RetroBoardService RetroBoardService { get; set; }

    [Inject]
    private ColumnRemoveNotificationService ColumnRemoveNotificationService { get; set; }

    [Parameter]
    public Column Column { get; set; }

    private void SetReadonly() => _isOverlayEnabled = true;

    private void SetEditable() => _isOverlayEnabled = false;

    private void CreateCard()
    {
        _isCardCreatePressed = false;

        Column.Cards.Add(new() { ColumnName = Column.Name, Title = _cardTitle, Content = _cardContent });
        _cardTitle = String.Empty;
        _cardContent = String.Empty;
    }

    private async Task RemoveColumnAsync(MouseEventArgs obj)
    {
        RetroBoardService.Boards.Single(x => x.Id == Column.BoardId).Columns.Remove(Column);
        await ColumnRemoveNotificationService.NotifyAsync();
    }

    private async Task RemoveCardAsync(Card card)
    {
        Column.Cards.Remove(card);
        await ColumnRemoveNotificationService.NotifyAsync();
    }
}