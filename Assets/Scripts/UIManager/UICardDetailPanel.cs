using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UICardDetailPanel : MonoBehaviour
{
    public static UICardDetailPanel Instance;

    public GameObject root;
    public TMP_Text descText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        root.SetActive(false); 
    }

    public void Show(CardConfig card)
    {
        if (card == null) return;

        root.SetActive(true);
        descText.text = card.cardDescription;
    }

    public void Hide()
    {
        root.SetActive(false);
    }
}