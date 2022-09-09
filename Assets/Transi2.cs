using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Transi2 : MonoBehaviour
{
    [SerializeField] private GameObject _bgToMove;
    [SerializeField] private GameObject _staticBG;
    [SerializeField] private GameObject _fusee;
    [SerializeField] private Transform[] _fuseePos;

    [SerializeField] private float _valueYTransiOn;
    [SerializeField] private float _timeTransiOn;
    [SerializeField] private float _timeTransiOff;

    private bool isTransi = false;

    private void Start()
    {
        TransiOn();
    }

    public void TransiOn()
    {
        if (isTransi)
            return;

        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y + _valueYTransiOn, _timeTransiOn).OnComplete(EndTransiOn);
        isTransi = true;
    }

    private void EndTransiOn()
    {
        _fusee.transform.position = _fuseePos[1].transform.position;
        isTransi = false;
    }


    public void TransiOff()
    {
        if (isTransi)
            return;

        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y + _valueYTransiOn, _timeTransiOff).OnComplete(EndTransiOff);
        isTransi = true;
    }

    private void EndTransiOff()
    {
        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y - _valueYTransiOn*2, 0);
        _fusee.transform.position = _fuseePos[0].transform.position;
        isTransi = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransiOff();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TransiOn();
        }
    }
}
