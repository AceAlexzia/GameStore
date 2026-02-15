using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Features.Games.UpdateGame;

// Add data Annotation here
public record UpdateGameDTO(
    [Required][StringLength(50)] string name,
    Guid genreId,
    [Range(1, 500)] decimal price,
    DateOnly releaseDate,
    [Required] string description
);
