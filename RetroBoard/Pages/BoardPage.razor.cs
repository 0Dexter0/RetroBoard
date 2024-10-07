using Microsoft.AspNetCore.Components;
using MudBlazor;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Pages;

public partial class BoardPage : ComponentBase, IDisposable
{
    private Board _board;
    private string _newColumnName = String.Empty;

    [Inject]
    private IRetroBoardService BoardService { get; set; }

    [Inject]
    private ColumnRemoveNotificationService ColumnRemoveNotificationService { get; set; }

    [Parameter]
    public string BoardId { get; set; }

    public void Dispose()
    {
        ColumnRemoveNotificationService.Notification -= OnNotifyAsync;
    }

    protected override async Task OnInitializedAsync()
    {
        _board = BoardService.GetBoards().Single(x => x.Id.ToString() == BoardId);
        ColumnRemoveNotificationService.Notification += OnNotifyAsync;
    }

    private Task OnNotifyAsync() => InvokeAsync(StateHasChanged);

    private void CreateColumn()
    {
        Column column = new() { Name = _newColumnName.Trim(), BoardId = _board.Id };
        _newColumnName = String.Empty;
        _board.Columns.Add(column);
    }

    private void ItemDropped(MudItemDropInfo<Card> itemInfo)
    {
        string oldColumnName = itemInfo.Item!.ColumnName;
        itemInfo.Item.ColumnName = itemInfo.DropzoneIdentifier;

        if (oldColumnName != itemInfo.DropzoneIdentifier)
        {
            var oldColumn = _board.Columns.First(x => x.Name == oldColumnName);
            oldColumn.Cards.RemoveAt(oldColumn.Cards.FindIndex(x => x.Content == itemInfo.Item.Content));
            _board.Columns.First(x => x.Name == itemInfo.Item.ColumnName).Cards.Add(itemInfo.Item);
        }
    }
}