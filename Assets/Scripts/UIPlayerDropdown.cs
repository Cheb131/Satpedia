using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class UIPlayerDropdown : MonoBehaviour
{
    public static UIPlayerDropdown Instance;

    public TMP_Dropdown dropdown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Refresh();
    }

    // =============================
    // Refresh dropdown từ PickSkill
    // =============================
    public void Refresh()
    {
        dropdown.ClearOptions();

        List<string> options = new();

        foreach (var player in PickSkill.Instance.players)
        {
            options.Add(player.playerId);
        }

        dropdown.AddOptions(options);

        if (options.Count > 0)
            dropdown.value = options.Count - 1;
    }

    // =============================
    // Player hiện tại
    // =============================
    public string CurrentPlayer
    {
        get
        {
            if (dropdown.options.Count == 0)
                return null;

            return dropdown.options[dropdown.value].text;
        }
    }
}
