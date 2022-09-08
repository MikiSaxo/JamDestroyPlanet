using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newMultiplicator", menuName = "ScriptableObjects/Multiplicator", order = 1)]
public class Multiplicator : Card
{
    [SerializeField] private int coefmultiplicator;

    public int CoefMultiplicator => coefmultiplicator;
}
