using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillRollItem : MonoBehaviour
{
    public Button button;
    private SkillConfig skillConfig;

    public void Setup(SkillConfig config)
    {
        skillConfig = config;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClickSkill);
    }

    void OnClickSkill()
    {
        // Phát voice khi ch?n skill
        

        // N?u b?n có logic ch?n skill, g?i ? ?ây
        Debug.Log("Ch?n skill: " + skillConfig.skillName);
    }
}
