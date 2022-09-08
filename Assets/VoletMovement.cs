using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VoletMovement : MonoBehaviour
{
    [SerializeField] private GameObject volet = null;
    [SerializeField] private float distance = 0;
    [SerializeField] private float timeToMove = 0;

    private bool isClosed = false;
    private bool isUsed = false;

    [Header ("MACHIN")]
    [Space (100f)]
    [Range (0f,1f)]
    [SerializeField] private float machin;


    public void BougerVolet()
    {
        if (isUsed)
            return;

        isUsed = true;

        volet.transform.DOComplete();

        volet.transform.DOMoveX(volet.transform.position.x - distance, timeToMove).OnComplete(UnlockVoletMove);
        distance *= -1;
    }

    public void UnlockVoletMove()
    {
        isUsed = false;
    }
}
