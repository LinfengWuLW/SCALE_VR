using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class StackingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.grey;
    public Color32 m_DownColor = Color.green;

    private Image m_Image = null;

    public bool isStackAction;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean trigger_StackingAction;

   


    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        //m_Image.color = m_HoverColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
        //m_Image.color = m_DownColor;
        if (trigger_StackingAction.GetStateDown(m_TargetSource))
        {
            isStackAction = true;
        }
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        //m_Image.color = m_HoverColor;

        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        //m_Image.color = m_NormalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");
        isStackAction = false;
       
    }


}
