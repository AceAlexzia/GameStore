using System;
using GameStore.Api.Models;
using GameStore.Api.Data;
using GameStore.Api.Features.Games.UpdateGame;

namespace GameStore.Api.Features;

public static class UpdateGameEndpoint
{
    public static void MapUpdateGame(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", (Guid id, UpdateGameDTO gameDTO, GameStoreData data) =>
        {
            Models.Game? existingGame = data.GetGame(id);
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

    }
}
