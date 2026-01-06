using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class UISkillDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<SkillConfig> allSkills;

    void Start()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(allSkills.ConvertAll(s => s.skillName));
    }

    public SkillConfig GetSelectedSkill()
    {
        if (allSkills == null || allSkills.Count == 0)
        {
            Debug.LogWarning("No skill in dropdown");
            return null;
        }

        if (dropdown.value < 0 || dropdown.value >= allSkills.Count)
            return null;

        return allSkills[dropdown.value];
    }

}
