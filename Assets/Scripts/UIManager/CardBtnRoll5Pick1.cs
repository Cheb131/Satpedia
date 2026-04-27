using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardBtnRoll5Pick1 : MonoBehaviour
{
    [Header("Data")]
    public List<CardConfig> allCards;

    [Header("UI References")]
    public UISkillListForPlayer skillListUI;

    [Header("UI")]
    public Button buttonRoll;
    public GameObject uiStatic;
    public GameObject cardPanel;

    [Header("Roll UI (size = 5)")]
    public Button[] cardButtons;      // size = 5
    public Image[] cardImages;

    private List<CardConfig> rolledCards = new();

    void Start()
    {
        cardPanel.SetActive(false);

        buttonRoll.onClick.AddListener(OnClick);
    }

    // =============================
    // Khi nhấn nút 
    // =============================
    void OnClick()
    {
        RollCard();

        uiStatic.SetActive(false);
        cardPanel.SetActive(true);
    }

    // =============================
    // Roll 5 card
    // =============================
    void RollCard()
    {
        const int ROLL_COUNT = 5;

        if (allCards == null || allCards.Count < ROLL_COUNT) return;
        if (cardButtons == null || cardButtons.Length < ROLL_COUNT) return;
        if (cardImages == null || cardImages.Length < ROLL_COUNT) return;

        rolledCards.Clear();

        List<CardConfig> temp = new(allCards);

        for (int i = 0; i < ROLL_COUNT; i++)
        {
            int rand = Random.Range(0, temp.Count);
            rolledCards.Add(temp[rand]);
            temp.RemoveAt(rand);
        }

        for (int i = 0; i < ROLL_COUNT; i++)
        {
            CardConfig card = rolledCards[i];

            // Show name + image
            cardImages[i].sprite = card != null ? card.cardImage : null;

            // Bind click
            cardButtons[i].onClick.RemoveAllListeners();
            cardButtons[i].onClick.AddListener(() =>
            {
                OnSelectCard(card);
            });
        }
    }

    // =============================
    // Khi chọn 1 card
    // =============================
    void OnSelectCard(CardConfig card)
    {
        string playerId = UIPlayerDropdown.Instance.CurrentPlayer;
        if (string.IsNullOrEmpty(playerId)) return;

        PickCard.Instance.AddCard(playerId, card);

        var player = PickCard.Instance.GetPlayer(playerId);
        if (player == null) return;

        // giống SkillBtnRoll3Pick1: ưu tiên singleton, hoặc dùng reference nếu bạn muốn
        if (UISkillListForPlayer.Instance != null) UISkillListForPlayer.Instance.ShowPlayer(player);
        else if (skillListUI != null) skillListUI.ShowPlayer(player);

        cardPanel.SetActive(false);
        uiStatic.SetActive(true);
    }
}
