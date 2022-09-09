using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class OnClickImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log(name + " Game Object Click in Progress");
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + " No longer being clicked");
    }
}