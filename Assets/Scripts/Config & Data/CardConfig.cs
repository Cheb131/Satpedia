using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardConfig", menuName = "Config/Card")]

public class CardConfig : ScriptableObject
{
    public string cardName;

    public Sprite cardImage;

    [TextArea(3, 10)]
    public string cardDescription;
}
