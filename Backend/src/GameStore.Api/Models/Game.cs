using System;

namespace GameStore.Api.Models;

public class Game
{
    public Guid id { get; set; }
    public required string name { get; set; }
    public required Genre genre { get; set; }

    public decimal price { get; set; }
    public DateOnly releaseDate { get; set; }
    public required string description { get; set; }
}
