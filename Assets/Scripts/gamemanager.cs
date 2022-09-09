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
    [SerializeField] private int devellopmentSpeed = 1;

    public TextMeshProUGUI yearsTxt;
    public TextMeshProUGUI populationTxt;
    public Image devellopmentBar;


    private void Start()
    {
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

    void NewCards(List<Card> Cards)
    {

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
