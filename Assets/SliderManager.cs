using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    private static SliderManager instance;
    [SerializeField] private Image[] _sliders;
    [SerializeField] private float[] _amountToReach;
    [SerializeField] private GameObject _fusee;
    [SerializeField] private Transform[] _pointfusee;

    private float t, t2, t3 = 0f;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    public static void ChangeSlide(int index, float _amount)
    {
        instance._amountToReach[index] = _amount;
    }

    private void Update()
    {
        if(_sliders[0].fillAmount != _amountToReach[0])
        {
            _sliders[0].fillAmount = Mathf.Lerp(_sliders[0].fillAmount, _amountToReach[0], t);
            t += .01f * Time.deltaTime;
        }

        if (_sliders[1].fillAmount != _amountToReach[1])
        {
            _sliders[1].fillAmount = Mathf.Lerp(_sliders[1].fillAmount, _amountToReach[1], t2);
            t3 = _sliders[1].fillAmount;
            _fusee.transform.position = new Vector3(Mathf.Lerp(_pointfusee[0].position.x, _pointfusee[1].position.x, t3), _pointfusee[0].position.y, 0);
            t2 += .01f * Time.deltaTime;
        }
    }
}