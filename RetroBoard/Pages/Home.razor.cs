using Microsoft.AspNetCore.Components;
using RetroBoard.Shared.Models;
using RetroBoard.Shared.Services;

namespace RetroBoard.Pages;

public partial class Home
{
    [Inject]
    private NavigationManager Navigator { get; init; }

    [Inject]
    private IRetroBoardService BoardService { get; init; }
    public string BoardName { get; set; } = string.Empty;

    private void CreateBoard()
    {
        Board board = new() { Name = BoardName, Id = Guid.NewGuid() };
        BoardService.AddBoard(board);
        Navigator.NavigateTo($"boards/{board.Id.ToString()}");
    }
}