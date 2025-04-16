using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameGraph gameGraph; // Ссылка на граф узлов
    private Stack<CardNode> history = new Stack<CardNode>(); // Стек для отката ходов
    private CardNode currentCard;
    [SerializeField] public TextMeshProUGUI TextCard;
    [SerializeField] public TextMeshProUGUI PositiveText;
    [SerializeField] public TextMeshProUGUI NegativeText;
    private int Positive = 50;
    private int Negative = 50;
    private int PastPositive = 50;
    private int PastNegative = 50;

    void Start()
    {
        PositiveText.text = Positive.ToString();
        NegativeText.text = Negative.ToString();
        ShowNextCard();
    }

    void ShowNextCard()
    {
        if (currentCard != null)
        {
            history.Push(currentCard); // Сохраняем текущую карточку в историю
        }

        // Получаем следующую карточку (например, первую из графа)
        currentCard = gameGraph.nodes[Random.Range(0, gameGraph.nodes.Count)] as CardNode;
        DisplayCard(currentCard);
    }

    void DisplayCard(CardNode card)
    {
        Debug.Log(card.cardText); // Здесь вы можете обновить UI с текстом карточки
        TextCard.text = card.cardText;

    }

    public void SayYes()
    {
        PastPositive = Positive; 
        PastNegative = Negative;
        Positive += currentCard.positiveEffect;
        Negative -= currentCard.negativeEffect;
        PositiveText.text = Positive.ToString();
        NegativeText.text = Negative.ToString();
        ShowNextCard();
    }

    public void SayNo()
    {
        PastPositive = Positive;
        PastNegative = Negative;
        Positive -= currentCard.positiveEffect;
        Negative += currentCard.negativeEffect;
        PositiveText.text = Positive.ToString();
        NegativeText.text = Negative.ToString();
        ShowNextCard();
    }

    public void GoBack()
    {
        if (history.Count > 0)
        {
            currentCard = history.Pop(); // Возвращаемся к предыдущей карточке
            Positive = PastPositive;
            Negative = PastNegative;
            PositiveText.text = Positive.ToString();
            NegativeText.text = Negative.ToString();
            DisplayCard(currentCard);
        }
    }
}