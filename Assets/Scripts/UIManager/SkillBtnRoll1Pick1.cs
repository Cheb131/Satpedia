using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBtnRoll1Pick1 : MonoBehaviour
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

        if (allSkills == null || allSkills.Count == 0)
        {
            Debug.LogWarning("❌ allSkills rỗng");
            return;
        }

        // 1️⃣ random 1 skill
        int rand = Random.Range(0, allSkills.Count);
        SkillConfig skill = allSkills[rand];
        rolledSkills.Add(skill);

        // 2️⃣ chỉ dùng button đầu tiên
        Button btn = skillButtons[0];

        btn.GetComponentInChildren<TMP_Text>().text = skill.skillName;

        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            OnSelectSkill(skill);
        });

        // 3️⃣ ẩn các button còn lại (nếu có)
        for (int i = 1; i < skillButtons.Length; i++)
        {
            skillButtons[i].gameObject.SetActive(false);
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
