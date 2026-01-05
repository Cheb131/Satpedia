using UnityEngine;

public class UIAddPlayerButton : MonoBehaviour
{
    public UIPlayerDropdown playerDropdown;

    public void AddPlayer()
    {
        int count = PickSkill.Instance.players.Count + 1;
        PickSkill.Instance.AddPlayer("Player " + count);
        playerDropdown.Refresh();
    }
}
