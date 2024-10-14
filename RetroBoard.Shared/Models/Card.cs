namespace RetroBoard.Shared.Models;

public class Card
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string ColumnId { get; set; }

    public List<Guid> LikedBy { get; init; } = [];

    public List<ActionItem> ActionItems { get; init; } = [];
}