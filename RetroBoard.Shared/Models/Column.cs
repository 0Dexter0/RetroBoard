namespace RetroBoard.Shared.Models;

public class Column
{
    public Guid BoardId { get; set; }
    public string Name { get; set; }

    public List<Card> Cards { get; set; } = new();
}