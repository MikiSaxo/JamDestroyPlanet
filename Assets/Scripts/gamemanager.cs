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


    private void Start()
    {
        PlusYear();
    }

    //Launch after using a card or takin one in inventory
    void NextTurn()
    {

    }

    //Create cards for the next Turn
    void NewCards(List<Card> Cards)
    {

    }

    void PlusYear()
    {
        years++;
        yearsTxt.text = ("An " + years.ToString());
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

    //Functions Art (FX meteor & others)
}
