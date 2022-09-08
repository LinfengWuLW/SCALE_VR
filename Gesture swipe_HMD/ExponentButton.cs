using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class ExponentButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    private Color32 m_NormalColor = Color.white;
    private Color32 m_DownColor = Color.green;
    private Color32 m_HoverColor = new Color32(231,56,112,255);

    public TextMeshProUGUI exponentText1;
    public TextMeshProUGUI exponentText2;

    public GameObject exponentArrowLong;
    public GameObject exponentArrowShort;

    private Image m_Image = null;

    public bool scaleUp;
    public bool scaleDown;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean up_ClickAction;
    public SteamVR_Action_Boolean down_ClickAction;

    public SteamVR_Action_Boolean trigger_DownAction;

    public float exponentHitTime = float.MaxValue;


    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
        //m_Image.color = m_DownColor;
        if (up_ClickAction.GetStateDown(m_TargetSource))
        {
            scaleUp = true;
        }
        if (down_ClickAction.GetStateDown(m_TargetSource))
        {
            scaleDown = true;
        }

        if (trigger_DownAction.GetStateDown(m_TargetSource))
        {
            exponentHitTime = Time.realtimeSinceStartup;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        //m_Image.color = m_HoverColor;

        exponentText1.color = m_HoverColor;
        exponentText2.color = m_HoverColor;

        exponentArrowLong.SetActive(true);
        exponentArrowShort.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        //m_Image.color = m_NormalColor;

        exponentText1.color = m_NormalColor;
        exponentText2.color = m_NormalColor;

        exponentArrowLong.SetActive(false);
        exponentArrowShort.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");
        scaleUp = false;
        scaleDown = false;

        if (trigger_DownAction.GetStateUp(m_TargetSource))
        {
            exponentHitTime = float.MaxValue;
        }
    }


}
