using UnityEngine;

[CreateAssetMenu(fileName = "newCardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    enum CardType
    {
        disaster,
        crisis,
        coeff
    }

    [SerializeField] private CardType cardType;

    [SerializeField] private string cardName;
    [SerializeField] private string description;

    [SerializeField] private int delay;
    [SerializeField] private int duration;

    [SerializeField] private GameObject prefab;

    [SerializeField] private int damage;

    [SerializeField] private int coefmultiplicator;

    [SerializeField] private int populationDamage;
    [SerializeField] private int developmentDamage;
    [SerializeField] private float developmentSlow = 1;


    public string CardName => cardName;
    public string Description => description;

    public int Delay => delay;
    public int Duration => duration;

    public GameObject Prefab => prefab;

    public int Damage => damage;

    public int CoefMultiplicator => coefmultiplicator;

    public int PopulationDamage => populationDamage;
    public int DevelopmentDamage => developmentDamage;
    public float DevelopmentSlow => developmentSlow;
}

