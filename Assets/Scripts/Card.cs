using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
    public GameManager gameManager;

    //Sprite

    public Sprite people;
    public Sprite development;
    
    public Sprite plus;
    public Sprite minus;

    public Sprite typeDisaster;
    public Sprite typeCrisis;
    public Sprite typeDivine;

    //UI
    [SerializeField] public Image spriteType;
    [SerializeField] public Image spriteCard;
    [SerializeField] public Image damages;
    [SerializeField] public TextMeshProUGUI delayTxt;
    [SerializeField] public TextMeshProUGUI durationTxt;

    public void Init(CardData data)
    {
        gameManager = FindObjectOfType<GameManager>();
        cardData = data;

        delay = cardData.Delay;
        duration = cardData.Duration;

        populationDamage = cardData.PopulationDamage;
        developmentDamage = cardData.DevelopmentDamage;
        developmentSlow = cardData.DevelopmentSlow;

        delayTxt.text = (delay + gameManager.years).ToString() + "(+" + delay + ")";
        durationTxt.text = (duration.ToString() + " Turns");

        spriteCard.sprite = CardData.SpriteCard;
        spriteType.sprite = CardData.SpriteType;

        if ( populationDamage > 0 )
        {
            damages.sprite = people;
            damages.SetNativeSize();
        }
        else if ( developmentDamage > 0 || developmentSlow > 0)
        {
            damages.sprite = development;
            damages.SetNativeSize();
        }
    }
}
