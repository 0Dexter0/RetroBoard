namespace RetroBoard.Shared.Models;

public class Card
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string ColumnName { get; set; }

    public List<ActionItem> ActionItems { get; set; } = new();
}