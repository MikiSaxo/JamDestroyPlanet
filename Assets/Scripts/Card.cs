using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private string description;

    [SerializeField] private int delai;
    [SerializeField] private int duree;

    [SerializeField] private GameObject prefab;

    public string CardName => cardName;
    public string Description => description;

    public int Delai => delai;
    public int Duree => duree;

    private GameObject Prefab => prefab;
}
