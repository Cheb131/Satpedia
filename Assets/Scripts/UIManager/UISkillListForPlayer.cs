using UnityEngine;

public class UISkillListForPlayer : MonoBehaviour
{
    public static UISkillListForPlayer Instance;

    [Header("UI List Root")]
    public Transform contentRoot;

    [Header("Row Prefabs")]
    [Tooltip("Prefab có component UISkillRow")]
    public GameObject skillRowPrefab;

    [Tooltip("Prefab có component UICardRow")]
    public GameObject cardRowPrefab;

    [Header("Runtime")]
    public PlayerData currentPlayer;

    void Awake()
    {
        Instance = this;
    }

    public void ShowPlayer(PlayerData player)
    {
        currentPlayer = player;
        Refresh();
    }

    /// <summary>
    /// Refresh theo player ?ang ch?n t? UIPlayerDropdown (khuyên dùng).
    /// </summary>
    public void RefreshCurrentPlayerFromDropdown()
    {
        if (UIPlayerDropdown.Instance == null)
        {
            Debug.LogError("? UIPlayerDropdown.Instance = null (ch?a có UIPlayerDropdown trong scene?)");
            return;
        }

        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        if (string.IsNullOrEmpty(playerId))
        {
            Debug.LogWarning("? CurrentPlayer ?ang r?ng (ch?a ch?n player trên dropdown?)");
            return;
        }

        // L?y d? li?u t? c? 2 h? th?ng
        PlayerData pSkill = (PickSkill.Instance != null) ? PickSkill.Instance.GetPlayer(playerId) : null;
        PlayerData pCard = (PickCard.Instance != null) ? PickCard.Instance.GetPlayer(playerId) : null;

        // N?u có 1 trong 2 thì set làm current
        currentPlayer = pSkill != null ? pSkill : pCard;
        Refresh();
    }

    public void Refresh()
    {
        if (contentRoot == null)
        {
            Debug.LogError("? UISkillListForPlayer.contentRoot = null. Hãy kéo Content/Viewport/Content vào Inspector.");
            return;
        }

        // clear list
        foreach (Transform c in contentRoot)
            Destroy(c.gameObject);

        if (currentPlayer == null)
        {
            Debug.LogWarning("? currentPlayer = null (ch?a g?i ShowPlayer/RefreshCurrentPlayerFromDropdown)");
            return;
        }

        // L?y playerId t? currentPlayer
        string playerId = currentPlayer.playerId;
        if (string.IsNullOrEmpty(playerId))
        {
            Debug.LogError("? currentPlayer.playerId r?ng/null");
            return;
        }

        // L?y d? li?u t? 2 manager ?? hi?n th? chung
        PlayerData pSkill = (PickSkill.Instance != null) ? PickSkill.Instance.GetPlayer(playerId) : null;
        PlayerData pCard = (PickCard.Instance != null) ? PickCard.Instance.GetPlayer(playerId) : null;

        // ===== SKILLS =====
        if (skillRowPrefab == null)
        {
            Debug.LogError("? skillRowPrefab = null. Hãy kéo prefab SkillRow (có UISkillRow) vào Inspector.");
        }
        else if (pSkill != null && pSkill.skills != null)
        {
            foreach (var skill in pSkill.skills)
            {
                var go = Instantiate(skillRowPrefab, contentRoot);
                var row = go.GetComponent<UISkillRow>();
                if (row == null)
                {
                    Debug.LogError("? skillRowPrefab không có component UISkillRow");
                    Destroy(go);
                    continue;
                }
                row.Init(pSkill, skill);
            }
        }

        // ===== CARDS =====
        if (cardRowPrefab == null)
        {
            Debug.LogError("? cardRowPrefab = null. Hãy kéo prefab CardRow (có UICardRow) vào Inspector.");
        }
        else if (pCard != null && pCard.cards != null)
        {
            foreach (var card in pCard.cards)
            {
                var go = Instantiate(cardRowPrefab, contentRoot);
                var row = go.GetComponent<UICardRow>();
                if (row == null)
                {
                    Debug.LogError("? cardRowPrefab không có component UICardRow");
                    Destroy(go);
                    continue;
                }
                row.Init(pCard, card);
            }
        }
    }
}