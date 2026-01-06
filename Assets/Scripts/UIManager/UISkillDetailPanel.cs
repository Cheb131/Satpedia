using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UISkillDetailPanel : MonoBehaviour
{
    public static UISkillDetailPanel Instance;

    public GameObject root;
    public TMP_Text descText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        root.SetActive(false); // ?n lúc ??u
    }

    public void Show(SkillConfig skill)
    {
        if (skill == null) return;

        root.SetActive(true);
        descText.text = skill.skillDescription;
    }

    public void Hide()
    {
        root.SetActive(false);
    }
}
