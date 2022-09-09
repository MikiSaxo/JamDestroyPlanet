using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VoletMovement : MonoBehaviour
{
    [SerializeField] private GameObject _volet = null;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _duration = 0;

    private bool isUsed = false;

    public void BougerVolet()
    {
        if (isUsed)
            return;

        isUsed = true;

        _volet.transform.DOComplete();

        _volet.transform.DOMoveX(_volet.transform.position.x - _distance, _duration).OnComplete(UnlockVoletMove);
        _distance *= -1;
    }

    public void UnlockVoletMove()
    {
        isUsed = false;
    }
}
