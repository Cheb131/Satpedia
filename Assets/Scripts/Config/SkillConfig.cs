using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillConfig", menuName = "Config/Skill")]
public class SkillConfig : ScriptableObject
{
    public string skillName;

    [TextArea (3,10)]
    public string skillDescription;
    public List<string> urlVoice;
}
