using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Card : MonoBehaviour
{
    private CardData cardData;
   
    [System.NonSerialized] public int delay;
    [System.NonSerialized] public int duration;

    [System.NonSerialized] public int populationDamage;
    [System.NonSerialized] public int developmentDamage;
    [System.NonSerialized] public float developmentSlow = 1;

    [System.NonSerialized] public bool isNew = true;
    public CardData CardData => cardData;
    // Start is called before the first frame update
    public void Init(CardData data)
    {
        cardData = data;
        delay = cardData.Delay;
        duration = cardData.Duration;

        populationDamage = cardData.PopulationDamage;
        developmentDamage = cardData.DevelopmentDamage;
        developmentSlow = cardData.DevelopmentSlow;
        


    }
}
