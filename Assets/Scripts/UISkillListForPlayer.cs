using UnityEngine;

public class UISkillListForPlayer : MonoBehaviour
{
    public Transform contentRoot;
    public GameObject rowPrefab;

    public PlayerData currentPlayer;

    // =============================
    // UI g?i khi ??i player
    // =============================
    public void ShowPlayer(PlayerData player)
    {
        currentPlayer = player;
        Refresh();
    }

    // =============================
    // Refresh theo currentPlayer
    // =============================
    public void Refresh()
    {
        if (currentPlayer == null)
        {
            Debug.LogWarning("UISkillListForPlayer: currentPlayer null");
            return;
        }

        Debug.Log($"Refresh UI: {currentPlayer.playerId}, skill count = {currentPlayer.skills.Count}");

        foreach (Transform c in contentRoot)
            Destroy(c.gameObject);

        foreach (var skill in currentPlayer.skills)
            CreateSkillItem(skill);
    }

    // =============================
    // T?o 1 item skill
    // =============================
    void CreateSkillItem(SkillConfig skill)
    {
        GameObject go = Instantiate(rowPrefab, contentRoot);

        // ví d?: set text
        var txt = go.GetComponentInChildren<TMPro.TMP_Text>();
        if (txt != null)
            txt.text = skill.skillName;
    }
}
