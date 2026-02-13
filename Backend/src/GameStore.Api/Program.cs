using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<Game> games =
[
    new Game {
        id = Guid.NewGuid(),
        name = "FIFA 23",
        genre = "Sport",
        price = 69.99m,
        releaseDate = new DateOnly(2022, 9, 27)
    },
    new Game {
        id = Guid.NewGuid(),
        name = "Fire Emblem Three Houses",
        genre = "Turn-based Strategy",
        price = 59.99m,
        releaseDate = new DateOnly(2019, 7, 26)
    },
    new Game {
        id = Guid.NewGuid(),
        name = "Mario Kart World",
        genre = "Racing",
        price = 59.99m,
        releaseDate = new DateOnly(2025, 6, 5)
    }
];

// GET /games
app.MapGet("/games", () => games);

app.Run();
