using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    [SerializedField] private year = 0;
    
    void Start()
    {
        StartCoroutine();
    }

    void YearPlus()
    {
        year++;
    }
}
