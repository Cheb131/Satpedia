using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICardRollItem : MonoBehaviour
{
    public Button button;
    private CardConfig cardConfig;

    public void Setup(CardConfig config)
    {
        cardConfig = config;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClickCard);
    }

    void OnClickCard()
    {
        // Phát voice khi ch?n skill


        // N?u b?n có logic ch?n skill, g?i ? ?ây
        Debug.Log("Ch?n card: " + cardConfig);
    }
}
