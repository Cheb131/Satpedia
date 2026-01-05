using TMPro;
using UnityEngine;

public class UIPlayerDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public UISkillListForPlayer skillListUI;

    void Start()
    {
        Refresh();

        dropdown.onValueChanged.AddListener(OnPlayerChanged);
    }

    public void Refresh()
    {
        dropdown.ClearOptions();

        var options = PickSkill.Instance.players
            .ConvertAll(p => p.playerId);

        dropdown.AddOptions(options);

        if (PickSkill.Instance.players.Count == 0)
            return;

        dropdown.value = 0;
        OnPlayerChanged(0);
    }

    void OnPlayerChanged(int index)
    {
        if (index < 0 ||
            index >= PickSkill.Instance.players.Count)
            return;

        var player = PickSkill.Instance.players[index];
        skillListUI.ShowPlayer(player);
    }
}
