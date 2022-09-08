using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private string description;

    [SerializeField] private int delay;
    [SerializeField] private int duration;

    [SerializeField] private GameObject prefab;

    public string CardName => cardName;
    public string Description => description;

    public int Delay => delay;
    public int Duration => duration;

    public GameObject Prefab => prefab;
}
