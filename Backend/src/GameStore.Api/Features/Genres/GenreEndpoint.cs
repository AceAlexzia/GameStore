using System;
using GameStore.Api.Data;

namespace GameStore.Api.Features.Genres;

public static class GenreEndpoints
{
    public static void MapGenres(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/genres");
        // GET /genres
        group.MapGetGenres();
    }
}
