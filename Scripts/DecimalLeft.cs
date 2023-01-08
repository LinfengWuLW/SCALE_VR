using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class DecimalLeft : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Transform decimalButton;
    private float decimalLeftHitTime = float.MaxValue;
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

        decimalLeftHitTime = Time.realtimeSinceStartup;
        swipeTime = decimalLeftHitTime - decimalButton.GetComponent<DecimalButton>().decimalHitTime;

        if (swipeTime > 0 && swipeTime < 2f)
        {
            decimalButton.GetComponent<DecimalButton>().scaleDown = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        //m_Image.color = m_NormalColor;

        decimalLeftHitTime = float.MaxValue;
        swipeTime = float.MaxValue;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");
    }


}
