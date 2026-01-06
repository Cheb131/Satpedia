using System.Collections.Generic;

public class PlayerRepository
{
    private static PlayerRepository _instance;
    public static PlayerRepository Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PlayerRepository();
            return _instance;
        }
    }

    private Dictionary<string, PlayerData> players
        = new Dictionary<string, PlayerData>();

    private PlayerRepository() { }

    public PlayerData Get(string playerId)
    {
        if (!players.ContainsKey(playerId))
            players[playerId] = new PlayerData(playerId);

        return players[playerId];
    }

    public IEnumerable<PlayerData> GetAll()
    {
        return players.Values;
    }
}
