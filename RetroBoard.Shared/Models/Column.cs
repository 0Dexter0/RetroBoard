namespace RetroBoard.Shared.Models;

public class Column
{
    public Guid Id { get; init; }

    public Guid BoardId { get; init; }

    public string Name { get; set; }

    public List<Card> Cards { get; init; } = [];
}