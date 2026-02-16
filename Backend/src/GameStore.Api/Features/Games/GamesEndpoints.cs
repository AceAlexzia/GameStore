using System;
using GameStore.Api.Data;
using GameStore.Api.Features.Games.CreateGame;
using GameStore.Api.Features.Games.DeleteGame;
using GameStore.Api.Features.Games.GetGames;
using GameStore.Api.Features.GetGame;

namespace GameStore.Api.Features.Games;

public static class GamesEndpoints
{
    public static void MapGames(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/games");

        // GET /games
        group.MapGetGames();

        // GET /games/id
        group.MapGetGame();

        // Post /games
        group.MapCreateGame();

        // PUT /games/id
        group.MapUpdateGame();

        // DELETE /games/id
        group.MapDeleteGame();
    }
}
