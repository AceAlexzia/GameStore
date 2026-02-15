using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Features.Game.CreateGame;

public record CreateGameDTO(
    [Required][StringLength(50)] string name,
    Guid genreId,
    [Range(1, 500)] decimal price,
    DateOnly releaseDate,
    [Required] string description
);

public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);

