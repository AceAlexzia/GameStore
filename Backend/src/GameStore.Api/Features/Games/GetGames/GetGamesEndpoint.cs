using System;
using GameStore.Api.Data;

namespace GameStore.Api.Features.Games.GetGames;

public static class GetGamesEndpoint
{
    public static void MapGetGames(this IEndpointRouteBuilder app)
    {
        // GET /games
        app.MapGet("/", (GameStoreData data) => data.GetGames().Select(game => new GameSummaryDTO(
            game.id, game.name, game.genre.name, game.price, game.releaseDate
        )));
    }
}
