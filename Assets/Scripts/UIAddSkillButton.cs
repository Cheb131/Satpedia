using UnityEngine;

public class UIAddSkillButton : MonoBehaviour
{
    public UISkillDropdown skillDropdown;
    public UISkillListForPlayer skillListUI;

    public void AddSkill()
    {
        Debug.Log("AddSkill BUTTON CLICKED");

        var player = skillListUI.currentPlayer;
        if (player == null)
        {
            Debug.LogWarning("❌ CurrentPlayer = null");
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
        skillListUI.Refresh();
    }


}
