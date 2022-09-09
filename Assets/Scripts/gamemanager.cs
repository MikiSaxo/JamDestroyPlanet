using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int years = 2021;
    [SerializeField] private int population = 800000;
    [SerializeField] [Range(0, 100)] private float devellopmentPercentage = 0;
<<<<<<< HEAD
    
    public TextMeshProUGUI yearsTxt;
    public TextMeshProUGUI populationTxt;
    [SerializeField] Transform canvasTrasform;
    [SerializeField] private List<CardData> cards;
    [SerializeField] private const int drawCount = 3;
=======
    [SerializeField] private int devellopmentSpeed = 1;

    public TextMeshProUGUI yearsTxt;
    public TextMeshProUGUI populationTxt;
    public Image devellopmentBar;


>>>>>>> 73730f32ff111016da84f02aff566dba869c1af3
    private void Start()
    {
        NewCards();
        PlusYear();
        ChangePopulation();
        ChangeDevellopment();
    }

    //Launch after using a card or takin one in inventory

    void NextTurn()
    {
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
    }

    //Create cards for the next Turn
<<<<<<< HEAD
    void NewCards()
=======

    void NewCards(List<Card> Cards)
>>>>>>> 73730f32ff111016da84f02aff566dba869c1af3
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
        devellopmentPercentage += percent;
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
}
