using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBtnRoll3Pick1 : MonoBehaviour
{
    [Header("Data")]
    public List<SkillConfig> allSkills;

    [Header("UI References")]
    public UISkillListForPlayer skillListUI;

    [Header("UI")]
    public Button buttonRoll;
    public GameObject uiStatic;
    public GameObject skillPanel;
    public Button[] skillButtons; // size = 3

    private List<SkillConfig> rolledSkills = new();

    void Start()
    {
        skillPanel.SetActive(false);

        buttonRoll.onClick.AddListener(OnClick);
    }

    // =============================
    // Khi nhấn nút 
    // =============================
    void OnClick()
    {
        RollSkill();

        uiStatic.SetActive(false);
        skillPanel.SetActive(true);
    }

    // =============================
    // Roll 3 skill
    // =============================
    void RollSkill()
    {
        rolledSkills.Clear();

        List<SkillConfig> temp = new(allSkills);

        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, temp.Count);
            rolledSkills.Add(temp[rand]);
            temp.RemoveAt(rand);
        }

        for (int i = 0; i < 3; i++)
        {
            SkillConfig skill = rolledSkills[i];

            skillButtons[i]
                .GetComponentInChildren<TMP_Text>()
                .text = skill.skillName;

            skillButtons[i].onClick.RemoveAllListeners();
            skillButtons[i].onClick.AddListener(() =>
            {
                OnSelectSkill(skill);
            });
        }
    }

    // =============================
    // Khi chọn 1 skill
    // =============================
    void OnSelectSkill(SkillConfig skill)
    {
        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        if (string.IsNullOrEmpty(playerId)) return;

        PickSkill.Instance.AddSkill(playerId, skill);
        SkillVoicePlayer.Instance.PlayFromSkill(skill);

        var player = PickSkill.Instance.GetPlayer(playerId);
        UISkillListForPlayer.Instance.ShowPlayer(player);

        skillPanel.SetActive(false);
        uiStatic.SetActive(true);
    }


}
