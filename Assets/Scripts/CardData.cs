using UnityEngine;

[CreateAssetMenu(fileName = "newCardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        disaster,
        crisis,
        multiplicator
    }

    [SerializeField] private CardType typeCard;

    [SerializeField] private string cardName;
    [SerializeField] private string description;

    [SerializeField] [Range(1, 10)] private int delay;
    [SerializeField] [Range(1, 10)] private int duration;

    [SerializeField] private GameObject prefab;

    [Space(10)]
    [Header("Disaster & Crisis")]
    [Space(2)]
    [SerializeField] private int populationDamage;

    [Space(10)]
    [Header("Crisis")]
    [Space(2)]
    [SerializeField] private int developmentDamage;
    [SerializeField] private float developmentSlow = 1;

    [Space(10)]
    [Header("Multiplicator")]
    [Space(2)]
    [SerializeField] private int coefmultiplicator = 1;

    #region Getter

    public string CardName => cardName;
    public string Description => description;

    public int Delay => delay;
    public int Duration => duration;

    public GameObject Prefab => prefab;

    public int PopulationDamage => populationDamage;
    public int DevelopmentDamage => developmentDamage;
    public float DevelopmentSlow => developmentSlow;
    public int CoefMultiplicator => coefmultiplicator;

    public CardType TypeCard => typeCard;

    #endregion
}

