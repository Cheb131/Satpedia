using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillTimeBinhTai : MonoBehaviour
{
    [Header("Data")]
    public List<SkillConfig> allSkills;

    [Header("UI References")]
    public UISkillListForPlayer skillListUI;

    [Header("UI")]
    public Button buttonRoll;
    public GameObject panelPickTimeSkill;
    public GameObject skillPanel;
    public GameObject uiStatic;
    public Button[] skillButtons; // size = 3


    private List<SkillConfig> rolledSkills = new();
    void Start()
    {

        buttonRoll.onClick.AddListener(OnClick);
    }

    // =============================
    // Khi nhấn nút 
    // =============================
    void OnClick()
    {
        RollSkill();
        panelPickTimeSkill.SetActive(false);
        skillPanel.SetActive(true);
    }

    // =============================
    // Roll skill 
    // =============================
    void RollSkill()
    {
        rolledSkills.Clear();

        if (allSkills == null || allSkills.Count == 0)
        {
            Debug.LogWarning("❌ allSkills rỗng");
            return;
        }

        // 1️⃣ random 3 skill
        int rollCount = Mathf.Min(3, allSkills.Count);

        for (int i = 0; i < rollCount; i++)
        {
            int rand = Random.Range(0, allSkills.Count);
            SkillConfig skill = allSkills[rand];

            // tránh trùng (optional)
            if (rolledSkills.Contains(skill))
            {
                i--;
                continue;
            }

            rolledSkills.Add(skill);
        }

        // 2️⃣ chỉ dùng button đầu tiên
        for (int i = 0; i < rolledSkills.Count; i++)
        {
            Button btn = skillButtons[i];
            SkillConfig skill = rolledSkills[i];

            btn.gameObject.SetActive(true);
            btn.GetComponentInChildren<TMP_Text>().text = skill.skillName;

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                OnSelectSkill(skill);
            });
        }

        // 3️⃣ ẩn các button còn lại (nếu có)
        for (int i = rolledSkills.Count; i < skillButtons.Length; i++)
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
        panelPickTimeSkill.SetActive(false);
        uiStatic.SetActive(true);

    }
}
