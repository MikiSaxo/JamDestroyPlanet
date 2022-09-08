using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int years = 0;
    [SerializeField] private int population;
    [SerializeField] [Range(0, 100)] private float devellopmentPercentage;

    private void Start()
    {
        PlusYear();
    }

    void PlusYear()
    {
        years++;
    }

    void NextTurn()
    {

    }

}
