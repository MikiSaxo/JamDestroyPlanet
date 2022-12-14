using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class OnClickCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler
{
    private Card card;
    [SerializeField] private int waitingTime = 1;
    private void Start()
    {
        card = gameObject.GetComponent<Card>();
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartCoroutine(KeepCard());
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        StopCoroutine(KeepCard());
        if(pointerEventData.hovered.Count > 0)
        {
            GameManager.PlayCard(card);
        }
    }

    private IEnumerator KeepCard()
    {
        yield return new WaitForSeconds(waitingTime);
        GameManager.KeepCard(card);

    }
}