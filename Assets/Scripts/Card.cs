using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] CardData cardData;
   
    private int delay;
    private int duration;

    private int populationDamage;
    private int developmentDamage;
    private float developmentSlow = 1;
    // Start is called before the first frame update
    void Start()
    {
        delay = cardData.Delay;
        duration = cardData.Duration;

        if( cardData.GetType() == typeof(Crisis))
        {
            populationDamage = cardData.P
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
