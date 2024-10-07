using RetroBoard.Shared.Models;

namespace RetroBoard.Shared.Services;

public interface IRetroBoardService
{
    IReadOnlyCollection<Board> GetBoards();

    void AddBoard(Board board);
}