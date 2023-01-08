using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class DecimalButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{

    private Color32 m_NormalColor = Color.white;
    private Color32 m_HoverColor = Color.grey;
    private Color32 m_DownColor = Color.green;

    private Image m_Image = null;

    public bool scaleUp;
    public bool scaleDown;

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean right_ClickAction;
    public SteamVR_Action_Boolean left_ClickAction;

    public SteamVR_Action_Boolean trigger_DownAction;

    public float decimalHitTime = float.MaxValue;

    public TextMeshProUGUI decimalText;

    public GameObject decimalArrowLong;
    public GameObject decimalArrowShort;

    public GameObject jaggyBottom;

    public GameObject hintBottomFaint;
    public GameObject hintBottomFull;

    private int numberOfInteractions = 0;


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
        if (right_ClickAction.GetStateDown(m_TargetSource))
        {
            scaleUp = true;
        }
        if (left_ClickAction.GetStateDown(m_TargetSource))
        {
            scaleDown = true;
        }

        if (trigger_DownAction.GetStateDown(m_TargetSource))
        {
            decimalHitTime = Time.realtimeSinceStartup;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
        //m_Image.color = m_HoverColor;

        decimalText.fontSize = 0.05f;

        if (numberOfInteractions < 3)
        {
            decimalArrowLong.SetActive(true);
            decimalArrowShort.SetActive(false);
        }

        if (numberOfInteractions < 1)
        {
            hintBottomFaint.SetActive(false);
            hintBottomFull.SetActive(true);
        }
        if (numberOfInteractions < 2)
        {
            jaggyBottom.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
        //m_Image.color = m_NormalColor;

        decimalText.fontSize = 0.035f;

        if (numberOfInteractions < 3)
        {
            decimalArrowLong.SetActive(false);
            decimalArrowShort.SetActive(true);
        }

        if (numberOfInteractions < 1)
        {
            jaggyBottom.SetActive(true);
            hintBottomFaint.SetActive(true);
            hintBottomFull.SetActive(false);
        }
        if (numberOfInteractions < 2)
        {
            jaggyBottom.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");
        scaleUp = false;
        scaleDown = false;

        if (trigger_DownAction.GetStateUp(m_TargetSource))
        {
            decimalHitTime = float.MaxValue;
        }

        numberOfInteractions++;
        print("number of interactions: " + numberOfInteractions);
        if (numberOfInteractions == 1)
        {
            print("turn hints off");
            hintBottomFaint.SetActive(false);
            hintBottomFull.SetActive(false);
        }
        if (numberOfInteractions == 2)
        {
            jaggyBottom.SetActive(false);
        }
        if (numberOfInteractions == 3)
        {
            decimalArrowLong.SetActive(false);
            decimalArrowShort.SetActive(false);
        }
    }


}
