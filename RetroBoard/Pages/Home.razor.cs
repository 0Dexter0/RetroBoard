using RetroBoard.Shared.Models;

namespace RetroBoard.Pages;

public partial class Home
{
    public string BoardName { get; set; } = String.Empty;

    private async Task CreateBoardAsync()
    {
        Board board = new() { Name = BoardName, Id = Guid.NewGuid() };
        BoardService.AddBoard(board);
        Navigator.NavigateTo($"boards/{board.Id.ToString()}");
    }
}