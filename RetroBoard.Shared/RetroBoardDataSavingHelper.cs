using Microsoft.JSInterop;

namespace RetroBoard.Shared;

public class RetroBoardDataSavingHelper
{
    private readonly Action _action;

    public RetroBoardDataSavingHelper(Action action)
    {
        _action = action;
    }

    [JSInvokable]
    public void Execute() => _action.Invoke();
}