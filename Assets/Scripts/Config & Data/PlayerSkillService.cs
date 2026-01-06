using UnityEngine;

public static class PlayerSkillService
{
    public static void AddSkill(string playerId, SkillConfig skill)
    {
        if (skill == null)
        {
            Debug.LogWarning("Skill null");
            return;
        }

        PlayerData player =
            PlayerRepository.Instance.Get(playerId);

        player.skills.Add(skill);

        Debug.Log($"[ADD SKILL] {playerId} + {skill.skillName}");
    }

    public static void RemoveSkill(string playerId, SkillConfig skill)
    {
        PlayerData player =
            PlayerRepository.Instance.Get(playerId);

        player.skills.Remove(skill);
    }

    public static bool HasSkill(string playerId, SkillConfig skill)
    {
        PlayerData player =
            PlayerRepository.Instance.Get(playerId);

        return player.skills.Contains(skill);
    }
}
