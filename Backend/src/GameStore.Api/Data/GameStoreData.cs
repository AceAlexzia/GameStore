using System;
using GameStore.Api.Models;

namespace GameStore.Api.Data;

public class GameStoreData
{
    private readonly List<Genre> genres =
    [
        new Genre {
            id = new Guid("ff55f557-cb58-4c00-9331-3abbd15170cf"),
            name = "Sports"
        },
        new Genre {
            id = new Guid("0fa69308-0788-4596-88eb-5cae630f2baf"),
            name = "Turn-based Strategy"
        },
        new Genre {
            id = new Guid("360e0f74-c77e-4da7-bdbb-492357beb544"),
            name = "Racing"
        },
        new Genre {
            id = new Guid("cb4fa849-074b-4d58-ad10-a0bc40cbf097"),
            name = "Shooting"
        }
    ];

    private readonly List<Game> games;
    public GameStoreData()
    {
        games =
        [
            new Game {
                id = Guid.NewGuid(),
                name = "FIFA 23",
                genre = genres[0],
                price = 69.99m,
                releaseDate = new DateOnly(2022, 9, 27),
                description = "FIFA 23 is a football simulation game released in September 2022, marking the 30th and final installment in the EA and FIFA partnership."
            },
            new Game {
                id = Guid.NewGuid(),
                name = "Fire Emblem Three Houses",
                genre = genres[1],
                price = 59.99m,
                releaseDate = new DateOnly(2019, 7, 26),
                description = "Fire Emblem: Three Houses is a turn-based tactical RPG for Nintendo Switch where you play as a professor at a military academy on the continent of Fódlan. You choose one of three houses—Black Eagles, Blue Lions, or Golden Deer—to teach, training students in combat, building relationships, and eventually guiding them through a war-torn narrative. "
            },
            new Game
            {
                id = Guid.NewGuid(),
                name = "Mario Kart World",
                genre = genres[2],
                price = 59.99m,
                releaseDate = new DateOnly(2025, 6, 5),
                description = "Mario Kart World is a 2025 kart racing game developed by Nintendo EPD for the Nintendo Switch 2. As in previous Mario Kart games, players control Mario characters as they race against opponents. World introduces an open-world design and mode, off-roading techniques, an elimination mode, and unlockable costumes for the playable characters. Races support up to 24 players, twice as many as previous Mario Kart games."
            }
        ];
    }

    // Use IEnumerable because it will prevent exposed any data and prevent the modification
    public IEnumerable<Game> GetGames() => games;
    public IEnumerable<Genre> GetGenres() => genres;
    public Genre? GetGenre(Guid id) => genres.Find(genre => genre.id == id);

    public Game? GetGame(Guid id) => games.Find(game => game.id == id);

    public void AddGame(Game game)
    {
        game.id = Guid.NewGuid();
        games.Add(game);
    }

    public void RemoveGame(Guid id)
    {
        // No need to check just remove all of them that have the same id
        games.RemoveAll(game => game.id == id);
    }
}
