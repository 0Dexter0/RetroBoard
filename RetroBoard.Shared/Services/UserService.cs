using Blazored.LocalStorage;

namespace RetroBoard.Shared.Services;

internal class UserService : IUserService
{
    public Guid UserId { get; init; }

    public UserService(ISyncLocalStorageService localStorageService)
    {
        if (localStorageService.ContainKey(StorageConstants.UserId))
        {
            UserId = localStorageService.GetItem<Guid>(StorageConstants.UserId);
        }
        else
        {
            UserId = Guid.NewGuid();
            localStorageService.SetItem(StorageConstants.UserId, UserId);
        }
    }
}