using UnityEngine;

public class UIAddSkillButton : MonoBehaviour
{
    public UISkillDropdown skillDropdown;
    public UISkillListForPlayer skillListUI;

    public void AddSkill()
    {
        Debug.Log("AddSkill BUTTON CLICKED");

        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        if (string.IsNullOrEmpty(playerId))
        {
            Debug.LogWarning("❌ CurrentPlayerId = null");
            return;
        }

        var player = PickSkill.Instance.GetPlayer(playerId);
        if (player == null)
        {
            Debug.LogWarning("❌ PlayerData not found");
            return;
        }

        var skill = skillDropdown.GetSelectedSkill();
        if (skill == null)
        {
            Debug.LogWarning("❌ Skill = null");
            return;
        }

        Debug.Log($"✅ Add skill {skill.skillName} to {player.playerId}");

        PickSkill.Instance.AddSkill(player.playerId, skill);

        skillListUI.ShowPlayer(player);
    }


}
