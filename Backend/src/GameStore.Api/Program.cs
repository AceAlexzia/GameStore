using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string getGameEndpoingName = "GetGame";

GameStoreData data = new GameStoreData();

// GET /games
app.MapGet("/games", () => data.GetGames().Select(game => new GameSummaryDTO(
    game.id, game.name, game.genre.name, game.price, game.releaseDate
)));


// GET /games/id
app.MapGet("/games/{id}", (Guid id) =>
{
    Game? game = data.GetGame(id);
    return game is null ? Results.NotFound() : Results.Ok(
        new GameDetailsDTO(game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description)
    );
}).WithName(getGameEndpoingName);

// GET /genres
app.MapGet("/genres", () => data.GetGenres().Select(genres => new GenreDTO(genres.id, genres.name)));

// Post /games
app.MapPost("/games", (CreateGameDTO gameDTO) =>
{
    var genre = data.GetGenre(gameDTO.genreId);
    if (genre is null)
    {
        return Results.BadRequest("Invalid Genre id");
    }
    var game = new Game
    {
        name = gameDTO.name,
        genre = (Genre)genre,
        price = gameDTO.price,
        releaseDate = gameDTO.releaseDate,
        description = gameDTO.description
    };
    data.AddGame(game);

    return Results.CreatedAtRoute(getGameEndpoingName, new { id = game.id }, new GameDetailsDTO(
        game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description
    ));
}).WithParameterValidation();


// PUT /games/id
app.MapPut("/games/{id}", (Guid id, UpdateGameDTO gameDTO) =>
{
    Game? existingGame = data.GetGame(id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }

    var genre = data.GetGenre(gameDTO.genreId);
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
    data.RemoveGame(id);
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

