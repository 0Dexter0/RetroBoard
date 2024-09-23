using RetroBoard.Shared.Models;

namespace RetroBoard.Shared.Services;

public class RetroBoardService
{
    public List<Board> Boards { get; init; } = new()
    {
        new("B1")
        {
            Id = Guid.Empty,
            Columns =
            [
                new()
                {
                    Name = "Column1",
                    Cards =
                    [
                        new()
                        {
                            ColumnName = "Column1",
                            Content = "Card1",
                            Title = "C1"
                        },
                        new()
                        {
                            ColumnName = "Column1",
                            Content = "Card2",
                            Title = "C2"
                        },
                        new()
                        {
                            ColumnName = "Column1",
                            Content = "Card3",
                            Title = "C3"
                        }
                    ]
                }
            ]
        }
    };
}