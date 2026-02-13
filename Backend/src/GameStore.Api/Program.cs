using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getGameEndpoingName = "GetGame";

List<Genre> genres =
[
    new Genre {
        id = new Guid("ff55f557-cb58-4c00-9331-3abbd15170cf"),
        name = "Sports"
    },
    new Genre {
        id = new Guid("0fa69308-0788-4596-88eb-5cae630f2baf"),
        name = "Turn-based Strategy"
    },
    new Genre {
        id = new Guid("360e0f74-c77e-4da7-bdbb-492357beb544"),
        name = "Racing"
    },
    new Genre {
        id = new Guid("cb4fa849-074b-4d58-ad10-a0bc40cbf097"),
        name = "Shooting"
    }
];

List<Game> games =
[
    new Game {
        id = Guid.NewGuid(),
        name = "FIFA 23",
        genre = genres[0],
        price = 69.99m,
        releaseDate = new DateOnly(2022, 9, 27),
        description = "FIFA 23 is a football simulation game released in September 2022, marking the 30th and final installment in the EA and FIFA partnership."
    },
    new Game {
        id = Guid.NewGuid(),
        name = "Fire Emblem Three Houses",
        genre = genres[1],
        price = 59.99m,
        releaseDate = new DateOnly(2019, 7, 26),
        description = "Fire Emblem: Three Houses is a turn-based tactical RPG for Nintendo Switch where you play as a professor at a military academy on the continent of Fódlan. You choose one of three houses—Black Eagles, Blue Lions, or Golden Deer—to teach, training students in combat, building relationships, and eventually guiding them through a war-torn narrative. "
    },
    new Game {
        id = Guid.NewGuid(),
        name = "Mario Kart World",
        genre = genres[2],
        price = 59.99m,
        releaseDate = new DateOnly(2025, 6, 5),
        description = "Mario Kart World is a 2025 kart racing game developed by Nintendo EPD for the Nintendo Switch 2. As in previous Mario Kart games, players control Mario characters as they race against opponents. World introduces an open-world design and mode, off-roading techniques, an elimination mode, and unlockable costumes for the playable characters. Races support up to 24 players, twice as many as previous Mario Kart games."
    }
];

// GET /games
app.MapGet("/games", () => games.Select(game => new GameSummaryDTO(
    game.id, game.name, game.genre.name, game.price, game.releaseDate
)));


// GET /games/id
app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = games.Find(game => game.id == id);
    return game is null ? Results.NotFound() : Results.Ok(
        new GameDetailsDTO(game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description)
    );
}).WithName(getGameEndpoingName);

// GET /genres
app.MapGet("/genres", () => genres.Select(genres => new GenreDTO(genres.id, genres.name)));

// Post /games
app.MapPost("/games", (CreateGameDTO gameDTO) =>
{
    var genre = genres.Find(genre => genre.id == gameDTO.genreId);
    if (genre is null)
    {
        return Results.BadRequest("Invalid Genre id");
    }
    var game = new Game
    {
        id = Guid.NewGuid(),
        name = gameDTO.name,
        genre = genre,
        price = gameDTO.price,
        releaseDate = gameDTO.releaseDate,
        description = gameDTO.description
    };
    games.Add(game);

    return Results.CreatedAtRoute(getGameEndpoingName, new { id = game.id }, new GameDetailsDTO(
        game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description
    ));
}).WithParameterValidation();


// PUT /games/id
app.MapPut("/games/{id}", (Guid id, UpdateGameDTO gameDTO) =>
{
    Game? existingGame = games.Find(game => game.id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    var genre = genres.Find(genre => genre.id == gameDTO.genreId);
    if (genre is null)
    {
        return Results.BadRequest("Invalid Genre id");
    }
    existingGame.name = gameDTO.name;
    existingGame.genre = genre;
    existingGame.price = gameDTO.price;
    existingGame.releaseDate = gameDTO.releaseDate;
    existingGame.description = gameDTO.description;
    return Results.NoContent();
}).WithParameterValidation();

// DELETE /games/id
app.MapDelete("/games/{id}", (Guid id) =>
{
    // No need to check just remove all of them that have the same id
    games.RemoveAll(game => game.id == id);
    return Results.NoContent();
});

app.Run();

// record is un mutable / unchangable
// Use DTO to help not showing all unesscessary data + make data more organise
public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);

public record GameSummaryDTO(Guid id, string name, string genre, decimal price, DateOnly releaseDate);

public record GenreDTO(Guid id, string name);

public record CreateGameDTO(
    [Required][StringLength(50)] string name,
    Guid genreId,
    [Range(1, 500)] decimal price,
    DateOnly releaseDate,
    [Required] string description
);

// Add data Annotation here
public record UpdateGameDTO(
    [Required][StringLength(50)] string name,
    Guid genreId,
    [Range(1, 500)] decimal price,
    DateOnly releaseDate,
    [Required] string description
);

