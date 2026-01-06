using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillRow: MonoBehaviour
{
    public TMP_Text skillNameText;
    public Button removeButton;
    public Button selectButton;

    private PlayerData owner;
    private SkillConfig skill;

    public void Init(PlayerData player, SkillConfig skillData)
    {
        skill = skillData;
        owner = player;

        skillNameText.text = skill.skillName;

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() =>
        {
            if (UISkillDetailPanel.Instance == null)
            {
                Debug.LogError("❌ UISkillDetailPanel.Instance = null");
                return;
            }

            if (skill == null)
            {
                Debug.LogError("❌ skill = null");
                return;
            }

            UISkillDetailPanel.Instance.Show(skill);
        });

    }
    public void RemoveSkill()
    {
        PickSkill.Instance.RemoveSkill(owner.playerId, skill);

        // 🔥 refresh lại player hiện tại từ dropdown
        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        var player = PickSkill.Instance.GetPlayer(playerId);
        UISkillListForPlayer.Instance.ShowPlayer(player);
    }
}
