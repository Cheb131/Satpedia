using UnityEngine;

public class UIAddPlayerButton : MonoBehaviour
{
    public UIPlayerDropdown playerDropdown;

    public void AddPlayer()
    {
        int count = PickSkill.Instance.players.Count + 1;
        string playerId = "Player " + count;

        // 1?? Add data
        PickSkill.Instance.AddPlayer(playerId);

        // 2?? Add vào dropdown UI
        playerDropdown.players.Add(playerId);

        // 3?? Refresh dropdown
        playerDropdown.Refresh();

        Debug.Log($"? Added player: {playerId}");
    }
}
