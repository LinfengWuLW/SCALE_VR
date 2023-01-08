using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class ExponentUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Transform exponentButton;
    private float exponentUpHitTime = float.MaxValue;
    private float swipeTime = float.MaxValue;

    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
        //m_Image.color = m_DownColor;   

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        //m_Image.color = m_HoverColor;

        exponentUpHitTime = Time.realtimeSinceStartup;     
        swipeTime=exponentUpHitTime- exponentButton.GetComponent<ExponentButton>().exponentHitTime;

        if(swipeTime>0 && swipeTime<2f)
        {
            exponentButton.GetComponent<ExponentButton>().scaleUp = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        //m_Image.color = m_NormalColor;

        exponentUpHitTime = float.MaxValue;
        swipeTime = float.MaxValue;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");     
    }


}
