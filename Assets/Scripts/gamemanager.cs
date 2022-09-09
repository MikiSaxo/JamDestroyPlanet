using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("Humanity information")]
    [Space(2)]
    [SerializeField] private int years = 2021;
    [SerializeField] private int population = 800000;
    [SerializeField] [Range(0, 100)] private float devellopmentPercentage = 0;

    [Space(10)]
    [Header("UI Reference")]
    [Space(2)]
    [SerializeField] Transform canvasTrasform;
    public TextMeshProUGUI yearsTxt;
    public TextMeshProUGUI populationTxt;
    public Image devellopmentBar;
    public GameObject endTurnButton;

    [Space(10)]
    [Header("Gamerules")]
    [Space(2)]
    [SerializeField] private List<CardData> cards;
    [SerializeField] private int drawCount = 3;

    private float devellopmentSpeed = 1;


    private List<Card> delayCard = new List<Card>();
    private List<Card> durationCard = new List<Card>();
    private List<Card> currentCard = new List<Card>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);

        instance = this;
    }

    private void Start()
    {
        NextTurn();
    }

    //Launch after using a card or takin one in inventory

    public void NextTurn()
    {
        endTurnButton.SetActive(false);
        foreach (Card card in durationCard)
        {
            card.duration--;
            if (card.duration <= 0)
            {
                durationCard.Remove(card);
                Destroy(card.gameObject);
            }
            UseCard(card);

        }

        foreach (Card card in delayCard)
        {
            card.delay--;
            if (card.delay == 0)
            {
                UseCard(card);
                card.duration--;

                delayCard.Remove(card);
                if (card.duration > 0)
                {
                    durationCard.Add(card);
                }
                else
                {
                    Destroy(card.gameObject);
                }
            }
        }

        if (population <= 0)
        {
            Win();
        }

        if (devellopmentPercentage == 100)
        {
            Lose();
        }

        PlusYear();
        AddPopulation(10);
        if(devellopmentSpeed > 0)
        {
            AddDevellopment(15);
        }
        
        devellopmentSpeed = 1;
        NewCards();

    }

    //Use card
    void UseCard(Card card)
    {
        RemovePopulation(card.populationDamage);
        RemoveDevellopment(card.developmentDamage);
        devellopmentSpeed *= card.developmentSlow;

    }
    //Create cards for the next Turn
    void NewCards()
    {
        Canvas canvas = canvasTrasform.gameObject.GetComponent<Canvas>();
        List<CardData> drawableCards = new List<CardData>(cards);
        for (int i = 0; i < drawCount; i++)
        {
            int index = Random.Range(0, drawableCards.Count);
            CardData GeneratedCard = drawableCards[index];
            drawableCards.Remove(GeneratedCard);

            GameObject cardObject = Instantiate(GeneratedCard.Prefab, canvasTrasform);
            Card card = cardObject.GetComponent<Card>();
            card.Init(GeneratedCard);
            currentCard.Add(card);
            float xPosition = canvas.renderingDisplaySize.x / (drawCount + 1) * (i + 1);
            cardObject.transform.position = new Vector3(xPosition, canvas.renderingDisplaySize.y / 2, 0);
        }

    }

    void ChangeYear()
    {
        yearsTxt.text = ("An " + years.ToString());
    }

    void ChangePopulation()
    {
        populationTxt.text = ("Population : " + population.ToString());
    }

    void ChangeDevellopment()
    {
        float fillAmount = (float)devellopmentPercentage / (float)100;
        devellopmentBar.fillAmount = fillAmount;
    }

    //Functions Add or Remove values

    void PlusYear()
    {
        years++;
        ChangeYear();
    }

    void AddPopulation(int percent)
    {
        population += ((population / 100) * percent);
        ChangePopulation();
    }

    void AddDevellopment(int percent)
    {
        devellopmentPercentage += percent*devellopmentSpeed;
        devellopmentSpeed = 1;
        ChangeDevellopment();
    }

    void RemovePopulation(int percent)
    {
        population -= ((population / 100) * percent);
        ChangePopulation();
    }

    void RemoveDevellopment(int percent)
    {
        devellopmentPercentage -= percent;
        ChangeDevellopment();
    }

    void Lose()
    {

    }

    void Win()
    {

    }

    public static void PlayCard(Card card)
    {
        instance.delayCard.Add(card);

        if(card.isNew)
        {
            instance.endTurnButton.gameObject.SetActive(true);
            foreach(Card _card in instance.currentCard)
            {
                _card.gameObject.SetActive(false);
            }
            instance.currentCard.Clear();
        }
    }
}
