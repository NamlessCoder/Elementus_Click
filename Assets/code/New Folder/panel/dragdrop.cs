using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rt;
    private CanvasGroup cg;
    public Canvas mycanvas;
    public bool istrue;
    private void Start()
    {
        istrue = true;
        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        mycanvas = GameObject.FindWithTag("secim").GetComponent<Canvas>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (istrue)
        {
            rt.anchoredPosition += eventData.delta / mycanvas.scaleFactor;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }



}
