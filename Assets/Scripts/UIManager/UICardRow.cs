using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICardRow : MonoBehaviour
{
    public TMP_Text cardNameText;
    public Button removeButton;
    public Button selectButton;

    private PlayerData owner;
    private CardConfig card;

    public void Init(PlayerData player, CardConfig cardData)
    {
        owner = player;
        card = cardData;

        if (cardNameText != null)
            cardNameText.text = (card != null) ? card.cardName : "(null)";

        // N?u prefab b? set removeButton == selectButton (trùng nút), ?u tiên remove
        bool sameButton = (removeButton != null && selectButton != null && removeButton == selectButton);

        // SELECT
        if (!sameButton && selectButton != null)
        {
            selectButton.onClick.RemoveAllListeners();
            selectButton.onClick.AddListener(() =>
            {
                if (card == null) return;

                // N?u Instance null, t? tìm panel k? c? khi inactive
                EnsureCardDetailPanelInstance();

                if (UICardDetailPanel.Instance == null)
                {
                    Debug.LogWarning("? Không tìm th?y UICardDetailPanel trong scene (ho?c object ?ang inactive). B? qua Show().");
                    return;
                }

                UICardDetailPanel.Instance.Show(card);
            });
        }

        // REMOVE
        if (removeButton != null)
        {
            removeButton.onClick.RemoveAllListeners();
            removeButton.onClick.AddListener(RemoveCard);
        }
    }

    public void RemoveCard()
    {
        if (owner == null || card == null)
        {
            Debug.LogWarning("? RemoveCard b? g?i khi owner/card null");
            return;
        }

        if (PickCard.Instance == null)
        {
            Debug.LogError("? PickCard.Instance = null");
            return;
        }

        PickCard.Instance.RemoveCard(owner.playerId, card);

        // Refresh list chung Skill + Card
        if (UISkillListForPlayer.Instance != null)
            UISkillListForPlayer.Instance.RefreshCurrentPlayerFromDropdown();
    }

    private static void EnsureCardDetailPanelInstance()
    {
        if (UICardDetailPanel.Instance != null) return;

        // Find k? c? khi object ?ang inactive
        var panel = Object.FindObjectOfType<UICardDetailPanel>(true);
        if (panel != null)
            UICardDetailPanel.Instance = panel;
    }
}