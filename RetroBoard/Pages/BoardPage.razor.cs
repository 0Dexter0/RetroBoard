using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using RetroBoard.Shared;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Pages;

public partial class BoardPage : ComponentBase, IDisposable
{
    private Board _board;
    private string _newColumnName = String.Empty;

    private static Action _callSave;

    [Inject]
    private IRetroBoardService BoardService { get; init; }

    [Inject]
    private ColumnRemoveNotificationService ColumnRemoveNotificationService { get; init; }

    [Inject]
    private ISyncSessionStorageService SessionStorageService { get; init; }

    [Inject]
    private IJSRuntime JsRuntime { get; init; }

    [Parameter]
    public string BoardId { get; set; }

    public void Dispose()
    {
        ColumnRemoveNotificationService.Notification -= OnNotifyAsync;
    }

    [JSInvokable]
    public static void SaveBeforeReload() => _callSave?.Invoke();

    protected override async Task OnInitializedAsync()
    {
        _board = BoardService.GetBoards().Single(x => x.Id.ToString() == BoardId);
        ColumnRemoveNotificationService.Notification += OnNotifyAsync;
        _callSave = SaveBeforeReloadInternal;
    }

    // protected override Task OnParametersSetAsync() => OnNotifyAsync();

    private Task OnNotifyAsync() => InvokeAsync(StateHasChanged);

    private void CreateColumn()
    {
        Column column = new() { Name = _newColumnName.Trim(), BoardId = _board.Id, Id = Guid.NewGuid() };
        _newColumnName = String.Empty;
        _board.Columns.Add(column);
    }

    private void ItemDropped(MudItemDropInfo<Card> itemInfo)
    {
        string oldColumnName = itemInfo.Item!.ColumnId;
        itemInfo.Item.ColumnId = itemInfo.DropzoneIdentifier;

        if (oldColumnName != itemInfo.DropzoneIdentifier)
        {
            var oldColumn = _board.Columns.First(x => x.Id.ToString() == oldColumnName);
            oldColumn.Cards.RemoveAt(oldColumn.Cards.FindIndex(x => x.Content == itemInfo.Item.Content));
            _board.Columns.First(x => x.Id.ToString() == itemInfo.Item.ColumnId).Cards.Add(itemInfo.Item);
        }
    }

    private void SaveBeforeReloadInternal()
    {
        if (SessionStorageService.ContainKey(StorageConstants.Boards))
        {
            SessionStorageService.RemoveItem(StorageConstants.Boards);
        }

        SessionStorageService.SetItem(StorageConstants.Boards, BoardService.GetBoards());
    }
}