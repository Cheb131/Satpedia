using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIPlayerDropdown : MonoBehaviour
{
    public static UIPlayerDropdown Instance;

    public TMP_Dropdown dropdown;
    public List<string> players = new();

    public string CurrentPlayer =>
        players.Count == 0 ? null : players[dropdown.value];

    void Awake()
    {
        Instance = this;
        dropdown.ClearOptions();
    }

    void Start()
    {
        dropdown.onValueChanged.AddListener(OnPlayerChanged);
    }

    void OnPlayerChanged(int index)
    {
        string playerId = CurrentPlayer;
        if (string.IsNullOrEmpty(playerId)) return;

        var player = PickSkill.Instance.GetPlayer(playerId);
        UISkillListForPlayer.Instance.ShowPlayer(player);
    }

    public void Refresh()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(players);
        dropdown.value = players.Count - 1;
        dropdown.RefreshShownValue();

        OnPlayerChanged(dropdown.value);
    }
}
