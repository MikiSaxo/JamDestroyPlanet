using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int years = 0;

    private void Start()
    {
        
    }

    void PlusYear()
    {
        years++;
    }
}
