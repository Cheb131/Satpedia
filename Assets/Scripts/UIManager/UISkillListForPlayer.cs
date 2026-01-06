using UnityEngine;

public class UISkillListForPlayer : MonoBehaviour
{
    public static UISkillListForPlayer Instance;

    public Transform contentRoot;
    public GameObject rowPrefab;

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

    public void Refresh()
    {
        foreach (Transform c in contentRoot)
            Destroy(c.gameObject);

        if (currentPlayer == null) return;

        foreach (var skill in currentPlayer.skills)
        {
            var go = Instantiate(rowPrefab, contentRoot);
            go.GetComponent<UISkillRow>()
              .Init(currentPlayer, skill);
        }
    }
}
