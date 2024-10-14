using Blazored.SessionStorage;
using RetroBoard.Shared.Models;

namespace RetroBoard.Shared.Services;

internal class RetroBoardService : IRetroBoardService
{
    private readonly List<Board> _boards = [];
    private readonly ISyncSessionStorageService _sessionStorageService;

    public RetroBoardService(ISyncSessionStorageService sessionStorageService)
    {
        _sessionStorageService = sessionStorageService;
    }

    public IReadOnlyCollection<Board> GetBoards()
    {
        if (_sessionStorageService.ContainKey(StorageConstants.Boards) && !_boards.Any())
        {
            _boards.AddRange(_sessionStorageService.GetItem<List<Board>>(StorageConstants.Boards));
        }

        return _boards;
    }

    public async void AddBoard(Board board)
    {
        _boards.Add(board);

        _sessionStorageService.SetItem(StorageConstants.Boards, _boards);
    }
}