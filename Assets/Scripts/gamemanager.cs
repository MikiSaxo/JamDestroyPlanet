using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int years = 0;
    [SerializeField] private int population = 1;
    [SerializeField] [Range(0, 100)] private float devellopmentPercentage = 0;
    
    public TextMeshProUGUI yearsTxt;
    public TextMeshProUGUI populationTxt;
    [SerializeField] Transform canvasTrasform;
    [SerializeField] private List<CardData> cards;
    [SerializeField] private const int drawCount = 3;
    private void Start()
    {
        NewCards();
        PlusYear();
    }

    //Launch after using a card or takin one in inventory
    void NextTurn()
    {
        PlusYear();
        if (devellopmentPercentage == 100)
        {
            Lose();
        }
    }

    //Create cards for the next Turn
    void NewCards()
    {
        Canvas canvas = canvasTrasform.gameObject.GetComponent<Canvas>();
        Debug.Log(canvas.renderingDisplaySize.x);
        List<CardData> drawableCards = cards;
        for (int i = 0; i < drawCount; i++)
        {
            int index = Random.Range(0, drawableCards.Count);
            CardData GeneratedCard = drawableCards[index];
            drawableCards.Remove(GeneratedCard);
            GameObject cardObject = Instantiate(GeneratedCard.Prefab, canvasTrasform);
            Card card = cardObject.GetComponent<Card>();
            card.Init(GeneratedCard);
            float xPosition = 0;
            if (drawCount % 2 == 0)
            {
                xPosition = canvas.renderingDisplaySize.x / (drawCount + 2) * (i + 1);
               
            }
            else
            {
                xPosition = canvas.renderingDisplaySize.x / (drawCount + 1) * (i + 1);
            }
            cardObject.transform.position = new Vector3(xPosition, canvas.renderingDisplaySize.y / 2, 0);
        }

    }

    void ChangeYear()
    {
        yearsTxt.text = ("An " + years.ToString());
    }

    //Functions Add or Remove values
    void PlusYear()
    {
        years++;
    }

    void AddPopulation(int percent)
    {
        population += ((population / 100) * percent);
    }

    void AddDevellopment(int percent)
    {
        population += percent;
    }

    void RemovePopulation(int percent)
    {
        population -= ((population / 100) * percent);
    }

    void RemoveDevellopment(int percent)
    {
        population -= percent;
    }

    void Lose()
    {

    }
}
