﻿namespace WebApplication2.Entities;

public class Game
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public decimal price { get; set; }

    public DateOnly Releasedate { get; set; }
}
