using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillBinhTai: MonoBehaviour
{

    [Header("UI")]
    public Button buttonRoll;
    public GameObject uiStatic;
    public GameObject skillTimePanel;
    public Button[] skillTimeButtons; // size = 3

    void Start()
    {
        skillTimePanel.SetActive(false);
        buttonRoll.onClick.AddListener(OnClick);
    }
    // =============================
    // Khi nhấn nút 
    // =============================
    void OnClick()
    {

        uiStatic.SetActive(false);
        skillTimePanel.SetActive(true);
    }
}
