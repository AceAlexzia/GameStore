using System;

namespace GameStore.Api.Features.Games.CreateGame;

using GameStore.Api.Features.Game.CreateGame;
using GameStore.Api.Data;
using GameStore.Api.Features.Games.Constants;
using GameStore.Api.Models;

public static class CreateGameEndpoint
{
    public static void MapCreateGame(this IEndpointRouteBuilder app, GameStoreData data)
    {
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

            return Results.CreatedAtRoute(EndpointNames.getGame, new { id = game.id }, new GameDetailsDTO(
                game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description
            ));
        }).WithParameterValidation();
    }
}
