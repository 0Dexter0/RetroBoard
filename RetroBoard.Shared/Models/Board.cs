﻿namespace RetroBoard.Shared.Models;

public class Board
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public List<Column> Columns { get; init; } = [];
}