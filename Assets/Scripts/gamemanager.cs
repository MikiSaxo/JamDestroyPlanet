using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int years = 0;
    [SerializeField] private int population = 1;
    [SerializeField] [Range(0, 100)] private float devellopmentPercentage = 0;

    private void Start()
    {
        PlusYear();
    }

    //Launch after using a card or takin one in inventory
    void NextTurn()
    {

    }

    //Create cards for the nexT Turn
    void NewCards(List<Card> Cards)
    {

    }

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
}
