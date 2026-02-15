namespace GameStore.Api.Features.Games.GetGames;

public record GameSummaryDTO(Guid id, string name, string genre, decimal price, DateOnly releaseDate);
