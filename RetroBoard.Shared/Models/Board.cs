namespace RetroBoard.Shared.Models;

public class Board
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public List<Column> Columns { get; init; } = new()
    {
        new() { Name = "Column1"}
    };

    public Board(string name)
    {
        // Id = Guid.NewGuid();
        Name = name;
    }
}