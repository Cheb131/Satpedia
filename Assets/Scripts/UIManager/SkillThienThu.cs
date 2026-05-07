using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillThienThu : MonoBehaviour
{
    [Header("Data")]
    public List<ThienThuConfig> allThienThu;

    [Header("UI References")]
    public UISkillListForPlayer skillListUI;

    [Header("UI")]
    public Button buttonRoll;

    public GameObject panelThienThu;
    public GameObject uiStatic;
    public Button[] thienThuButtons;
    public TMP_Text[] thienThuDescription;

    private bool isCause = false;
    private bool isConse = false;

    private List<ThienThuConfig> rolledThienThu = new();

    void Start()
    {
        buttonRoll.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        RollSkill();
        panelThienThu.SetActive(false);
        uiStatic.SetActive(true);
    }

    void RollSkill()
    {
        rolledThienThu.Clear();

        if (allThienThu == null || allThienThu.Count == 0)
        {
            Debug.LogWarning("❌ rỗng");
            return;
        }

        // 1️⃣ random 3 skill
        int rollCount = Mathf.Min(3, allThienThu.Count);

        for (int i = 0; i < rollCount; i++)
        {
            int rand = Random.Range(0, allThienThu.Count);
            ThienThuConfig skill = allThienThu[rand];

            // tránh trùng (optional)
            if (rolledThienThu.Contains(skill))
            {
                i--;
                continue;
            }

            rolledThienThu.Add(skill);
        }

        // 2️⃣ chỉ dùng button đầu tiên
        for (int i = 0; i < rolledThienThu.Count; i++)
        {
            Button btn = thienThuButtons[i];
            ThienThuConfig skill = rolledThienThu[i];

            btn.gameObject.SetActive(true);
            btn.GetComponentInChildren<TMP_Text>().text = skill.description;

            if (thienThuDescription != null && i < thienThuDescription.Length)
            {
                thienThuDescription[i].text = skill.description;
            }

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                OnSelectSkill(skill);
            });
        }

        // 3️⃣ ẩn các button còn lại (nếu có)
        for (int i = rolledThienThu.Count; i < thienThuButtons.Length; i++)
        {
            thienThuButtons[i].gameObject.SetActive(false);
        }
    }

    void OnSelectSkill(ThienThuConfig skill)
    {
        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        if (string.IsNullOrEmpty(playerId)) return;

        var player = PickSkill.Instance.GetPlayer(playerId);
        UISkillListForPlayer.Instance.ShowPlayer(player);

        //skillPanel.SetActive(false);
        //panelPickTimeSkill.SetActive(false);
        //uiStatic.SetActive(true);
    }
}
