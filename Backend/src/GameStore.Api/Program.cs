using GameStore.Api.Data;
using GameStore.Api.Features.Games;
using GameStore.Api.Features.Genres;

var builder = WebApplication.CreateBuilder(args);

// Register service
builder.Services.AddSingleton<GameStoreData>();
builder.Services.AddTransient<GameDataLogger>();

var app = builder.Build();

app.MapGames();
app.MapGenres();

app.Run();

// record is un mutable / unchangable
// Use DTO to help not showing all unesscessary data + make data more organise
public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);
