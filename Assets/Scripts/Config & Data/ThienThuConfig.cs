using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThienThuConfig", menuName = "Config/ThienThu")]

public class ThienThuConfig : ScriptableObject
{

    [TextArea(3, 10)]
    public string description;
}
