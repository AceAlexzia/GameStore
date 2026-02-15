using System;
using GameStore.Api.Data;

namespace GameStore.Api.Features.Genres;

public static class GetGenres
{
    public static void MapGetGenres(this IEndpointRouteBuilder app, GameStoreData data)
    {
        app.MapGet("/", () => data.GetGenres().Select(genres => new GenreDTO(genres.id, genres.name)));
    }
}
