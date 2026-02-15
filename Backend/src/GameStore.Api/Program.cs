using System.ComponentModel.DataAnnotations;
using GameStore.Api.Data;
using GameStore.Api.Features;
using GameStore.Api.Features.Games;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.DeleteGame;
using GameStore.Api.Features.Games.GetGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Features.Genres;
using GameStore.Api.Features.GetGame;



var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

GameStoreData data = new GameStoreData();

app.MapGames(data);
app.MapGenres(data);

app.Run();

// record is un mutable / unchangable
// Use DTO to help not showing all unesscessary data + make data more organise
public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);
