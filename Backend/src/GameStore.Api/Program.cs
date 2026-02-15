using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.Features;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.DeleteGame;
using GameStore.Api.Features.Games.GetGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Features.Genres;
using GameStore.Api.Features.GetGame;



var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

GameStoreData data = new GameStoreData();


// GET /games
app.MapGetGames(data);

// GET /games/id
app.MapGetGame(data);

// GET /genres
app.MapGetGenres(data);

// Post /games
app.MapCreateGame(data);


// PUT /games/id
app.MapUpdateGame(data);

// DELETE /games/id
app.MapDeleteGame(data);

app.Run();

// record is un mutable / unchangable
// Use DTO to help not showing all unesscessary data + make data more organise
public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);
