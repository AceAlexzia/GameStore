using System;
using GameStore.Api.Data;

namespace GameStore.Api.Features.Genres;

public static class GetGenres
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", (GameStoreData data) => data.GetGenres().Select(genres => new GenreDTO(genres.id, genres.name)));
    }
}
