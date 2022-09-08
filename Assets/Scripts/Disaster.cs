using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDisaster", menuName = "ScriptableObjects/Disaster", order = 1)]

public class Disaster : Card
{
    [SerializeField] private int damage;
            
    public int Damage => damage;
}
