using System;

namespace GameStore.Api.Models;

public class Genre
{
    public Guid id { get; set; }
    public required string name { get; set; }
}
