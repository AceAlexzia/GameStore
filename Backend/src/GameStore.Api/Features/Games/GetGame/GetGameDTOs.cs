namespace GameStore.Api.Features.Games.GetGame;

public record GameDetailsDTO(Guid id, string name, Guid genreId, decimal price, DateOnly releaseDate, string description);
