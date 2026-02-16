using System;

namespace GameStore.Api.Data;

public class GameDataLogger(GameStoreData data, ILogger<GameDataLogger> logger)
{
    public void PrintGames()
    {
        foreach (var game in data.GetGames())
        {
            logger.LogInformation("Game ID: {gameId} | Game Name: {gameName}", game.id, game.name);
        }
    }
}
