using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnSkillPanel: MonoBehaviour
{

    [Header("UI")]
    public Button buttonRoll;
    public GameObject uiStatic;
    public GameObject panelSkill;
    void Start()
    {
        panelSkill.SetActive(false);
        buttonRoll.onClick.AddListener(OnClick);
    }
    // =============================
    // Khi nhấn nút 
    // =============================
    void OnClick()
    {

        uiStatic.SetActive(false);
        panelSkill.SetActive(true);
    }
}
