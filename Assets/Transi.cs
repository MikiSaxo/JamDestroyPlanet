using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Transi : MonoBehaviour
{
    [SerializeField] private GameObject _bgToMove;
    [SerializeField] private GameObject _bgToRotate;
    [SerializeField] private GameObject _staticBG;

    [SerializeField] private float _valueYTransiOn;
    [SerializeField] private float _timeTransiOn;
    [SerializeField] private float _timeTransiOff;

    private void Start()
    {
        TransiOn();
    }

    public void TransiOn()
    {
        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y + _valueYTransiOn, _timeTransiOn).OnComplete(EndTransiOn);
    }

    private void EndTransiOn()
    {
        _staticBG.SetActive(true);
        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y - _valueYTransiOn, 0.1f);
        _bgToRotate.transform.DORotate(new Vector3(0, 0, 180), 0.1f).OnComplete(TransiOff);
    }

    public void TransiOff()
    {
        _staticBG.SetActive(false);
        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y + _valueYTransiOn, _timeTransiOff).OnComplete(EndTransiOff);
    }

    private void EndTransiOff()
    {
        _bgToMove.transform.localScale = Vector3.zero;
        _bgToMove.transform.DOMoveY(_bgToMove.transform.position.y - _valueYTransiOn, 0.1f);
        _bgToRotate.transform.DORotate(Vector3.zero, 0.1f).OnComplete(ResetScale);
    }


    private void ResetScale()
    {
        _bgToMove.transform.localScale = Vector3.one;
    }
}
