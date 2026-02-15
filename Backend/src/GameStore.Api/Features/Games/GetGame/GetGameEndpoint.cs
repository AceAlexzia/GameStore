using System;

namespace GameStore.Api.Features.GetGame;

using GameStore.Api.Models;
using GameStore.Api.Features.Games.Constants;
using GameStore.Api.Data;

public static class GetGameEndpoint
{
    public static void MapGetGame(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapGet("/{id}", (Guid id) =>
        {
            Game? game = data.GetGame(id);
            return game is null ? Results.NotFound() : Results.Ok(
                new GameDetailsDTO(game.id, game.name, game.genre.id, game.price, game.releaseDate, game.description)
            );
        }).WithName(EndpointNames.getGame);
    }
}
