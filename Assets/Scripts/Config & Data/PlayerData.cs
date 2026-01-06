using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string playerId;
    public List<SkillConfig> skills = new(); 

    public PlayerData(string id)
    {
        playerId = id;
    }
}
