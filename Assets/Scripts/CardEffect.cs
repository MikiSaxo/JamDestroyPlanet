using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect 
{

    [System.NonSerialized] public int delay;
    [System.NonSerialized] public int duration;

    [System.NonSerialized] public int populationDamage;
    [System.NonSerialized] public int developmentDamage;
    [System.NonSerialized] public float developmentSlow = 1;

    public CardEffect(Card card)
    {
        delay = card.CardData.Delay;
        duration = card.CardData.Duration;

        populationDamage = card.CardData.PopulationDamage;
        developmentDamage = card.CardData.DevelopmentDamage;
        developmentSlow = card.CardData.DevelopmentSlow;
    }
}
