namespace RetroBoard.Shared;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection is null || !collection.Any();
}