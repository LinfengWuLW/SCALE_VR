using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using TMPro;

public class PP6_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public SteamVR_Input_Sources m_TargetSource;

    public SteamVR_Action_Boolean trigger_PPAction;

    public int targetWorldIndex = 16;
    public bool triggerSignal;

    public TextMeshProUGUI number;

    private Color32 m_NormalColor = new Color32(18, 73, 81, 255);
    private Color32 m_HoverColor = new Color32(231, 56, 112, 255);

    public SpriteRenderer spriteRenderer;

    public GameObject hints;

    private void Awake()
    {
    }
    void Start()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //m_Image.color = m_HoverColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //m_Image.color = m_DownColor;
        if (trigger_PPAction.GetStateDown(m_TargetSource))
        {
            hints.SetActive(false);
            targetWorldIndex = 22;
            triggerSignal = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //m_Image.color = m_HoverColor;
        number.color = m_HoverColor;
        spriteRenderer.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //m_Image.color = m_NormalColor;
        number.color = m_NormalColor;
        spriteRenderer.color = m_NormalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        triggerSignal = false;
    }


}