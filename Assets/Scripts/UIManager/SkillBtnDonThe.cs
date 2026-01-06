using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBtnDonThe : MonoBehaviour
{
    [Header("Data")]
    public List<SkillConfig> allSkills;

    [Header("UI References")]
    public UISkillListForPlayer skillListUI;

    [Header("UI")]
    public Button buttonDonThe;
    public GameObject skillPanel;
    public Button[] skillButtons; // size = 3

    private List<SkillConfig> rolledSkills = new();

    void Start()
    {
        skillPanel.SetActive(false);

        buttonDonThe.onClick.AddListener(OnClickDonThe);
    }

    // =============================
    // Khi nhấn nút Độn Thế
    // =============================
    void OnClickDonThe()
    {
        RollSkill();

        buttonDonThe.gameObject.SetActive(false);
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
        string currentPlayer =
            UIPlayerDropdown.Instance.CurrentPlayer;

        PlayerSkillService.AddSkill(currentPlayer, skill);

        SkillVoicePlayer.Instance.PlayFromSkill(skill);

        PlayerData player =
            PlayerRepository.Instance.Get(currentPlayer);

        // ✅ KHÔNG DÙNG Instance
        skillListUI.ShowPlayer(player);

        skillPanel.SetActive(false);
        buttonDonThe.gameObject.SetActive(true);
    }


}
