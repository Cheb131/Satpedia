using UnityEngine;

public class UISkillListForPlayer : MonoBehaviour
{
    public Transform contentRoot;
    public GameObject rowPrefab;

    public PlayerData currentPlayer;

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
            var row = Instantiate(rowPrefab, contentRoot);
            row.GetComponent<UISkillRowForPlayer>()
                .Setup(currentPlayer.playerId, skill, this);
        }
    }
}
