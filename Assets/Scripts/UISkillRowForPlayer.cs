using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillRowForPlayer : MonoBehaviour
{
    public TMP_Text skillNameText;
    public Button removeButton;

    private string playerId;
    private SkillConfig skill;
    private UISkillListForPlayer listUI;

    public void Setup(string playerId, SkillConfig skill, UISkillListForPlayer listUI)
    {
        this.playerId = playerId;
        this.skill = skill;
        this.listUI = listUI;

        skillNameText.text = skill.skillName;

        removeButton.onClick.RemoveAllListeners();
        removeButton.onClick.AddListener(() =>
        {
            PickSkill.Instance.RemoveSkill(playerId, skill);
            listUI.Refresh();
        });
    }
}
