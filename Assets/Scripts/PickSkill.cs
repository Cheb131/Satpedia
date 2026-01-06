using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSkill : MonoBehaviour
{
    public static PickSkill Instance;
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
        players.Add(new PlayerData(playerId));
    }

    public void AddSkill(string playerId, SkillConfig skill)
    {
        var player = players.Find(p => p.playerId == playerId);
        if (player == null || skill == null) return;

        player.skills.Add(skill);
    }

    public void RemoveSkill(string playerId, SkillConfig skill)
    {
        var player = players.Find(p => p.playerId == playerId);
        if (player == null) return;

        player.skills.Remove(skill);
    }

    public PlayerData GetPlayer(string playerId)
    {
        return players.Find(p => p.playerId == playerId);
    }
}

