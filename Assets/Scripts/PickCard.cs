using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCard : MonoBehaviour
{
    public static PickCard Instance;
    public List<PlayerData> players = new();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddPlayer(string playerId)
    {
        if (string.IsNullOrEmpty(playerId)) return;
        if (players.Exists(p => p.playerId == playerId)) return;

        players.Add(new PlayerData(playerId));
    }

    public void AddCard(string playerId, CardConfig card)
    {
        if (string.IsNullOrEmpty(playerId) || card == null) return;

        var player = players.Find(p => p.playerId == playerId);
        if (player == null)
        {
            AddPlayer(playerId);
            player = players.Find(p => p.playerId == playerId);
            if (player == null) return;
        }

        player.cards.Add(card);
    }

    public void RemoveCard(string playerId, CardConfig card)
    {
        var player = players.Find(p => p.playerId == playerId);
        if (player == null) return;

        player.cards.Remove(card);
    }

    public PlayerData GetPlayer(string playerId)
    {
        return players.Find(p => p.playerId == playerId);
    }
}


