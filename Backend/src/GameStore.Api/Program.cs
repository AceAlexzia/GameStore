using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getGameEndpoingName = "GetGame";

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


// GET /games/id
app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(game => game.id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(getGameEndpoingName);

// Post /games
app.MapPost("/games", (Game game) =>
{
    game.id = Guid.NewGuid();
    games.Add(game);

    return Results.CreatedAtRoute(getGameEndpoingName, new { id = game.id }, game);
});

app.Run();
