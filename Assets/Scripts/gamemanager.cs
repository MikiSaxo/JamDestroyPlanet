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


    private void Start()
    {
        PlusYear();
    }

    //Launch after using a card or takin one in inventory

    void NextTurn()
    {
        PlusYear();
        if (population <= 0)
        {
            Win();
        }

        if (devellopmentPercentage == 100)
        {
            Lose();
        }
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
        populationTxt.text = ("An " + population.ToString());
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
        population += percent;
        ChangePopulation();
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

    void Win()
    {

    }
}
