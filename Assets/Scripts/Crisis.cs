
using UnityEngine;

[CreateAssetMenu(fileName = "newCrisis", menuName = "ScriptableObjects/Crisis", order = 1)]
public class Crisis : Card
{
    [SerializeField] private int populationDamage;
    [SerializeField] private int developmentDamage;
    [SerializeField] private float developmentSlow = 1;

    public int PopulationDamage => populationDamage;
    public int DevelopmentDamage => developmentDamage;
    public float DevelopmentSlow => developmentSlow;



}
