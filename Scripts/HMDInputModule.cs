using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class HMDInputModule : BaseInputModule
{
    public bool upFromButton2Exp;
    public bool scaleUpHandMotion2Exp;

    public bool upFromButton2Dec;
    public bool scaleUpHandMotion2Decimal;


    public bool downFromButton2Exp;
    public bool scaleDownHandMotion2Exp;

    public bool downFromButton2Dec;
    public bool scaleDownHandMotion2Decimal;


    public bool scaleUpC2Decimal;
    public bool scaleDownC2Decimal;
    public bool scaleDownC;
    public bool scaleUpC;

    public bool unitChangeRightC2UnitChangePanel;
    public bool unitChangeLeftC2UnitChangePanel;

    public bool upFromC2Scaling;
    public bool downFromC2Scaling;

    public bool scaleUpHandMotion;
    public bool scaleDownHandMotion;

    public bool isStackAction;


    public Camera m_Camera;
    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_ClickAction;
    public SteamVR_Action_Boolean up_ClickAction;
    public SteamVR_Action_Boolean down_ClickAction;
    public SteamVR_Action_Boolean right_ClickAction;
    public SteamVR_Action_Boolean left_ClickAction;

    private GameObject m_currentObject = null;
    private PointerEventData m_Data = null;


    protected override void Awake()
    {
        base.Awake();
        m_Data = new PointerEventData(eventSystem);
    }




    public override void Process()
    {
        //reset data, set camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);

        //raycast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_currentObject = m_Data.pointerCurrentRaycast.gameObject;

        //clear
        m_RaycastResultCache.Clear();

        //hover
        HandlePointerExitAndEnter(m_Data, m_currentObject);

        //Press
        if (m_ClickAction.GetStateDown(m_TargetSource) || left_ClickAction.GetStateDown(m_TargetSource) ||  right_ClickAction.GetStateDown(m_TargetSource) || up_ClickAction.GetStateDown(m_TargetSource) || down_ClickAction.GetStateDown(m_TargetSource))
            ProcessPress(m_Data);

        //Release
        if (m_ClickAction.GetStateUp(m_TargetSource) || left_ClickAction.GetStateUp(m_TargetSource) || right_ClickAction.GetStateUp(m_TargetSource) || up_ClickAction.GetStateUp(m_TargetSource) || down_ClickAction.GetStateUp(m_TargetSource))
            ProcessRelease(m_Data);

        //eventSystem.RaycastAll(Data, m_RaycastResultCache);
        //Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);

        //HandlePointerExitAndEnter(Data, Data.pointerCurrentRaycast.gameObject);
    }

    public PointerEventData GetData()
    {
        return m_Data;
    }
    public void ProcessPress(PointerEventData data)
    {
        // set rayset
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // check for object hit, get the down handler, call
        GameObject newPointPress = ExecuteEvents.ExecuteHierarchy(m_currentObject, data, ExecuteEvents.pointerDownHandler);

        // if no down handler, try  and get click handler
        if (newPointPress == null)
            newPointPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_currentObject);

        //set data
        data.pressPosition = data.position;
        data.pointerPress = newPointPress;
        data.rawPointerPress = m_currentObject;
    }


    public void ProcessRelease(PointerEventData data)
    {
        // execute pointer up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // check for click handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_currentObject);


        //check if actual
        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        //clear selected gameoject
        eventSystem.SetSelectedGameObject(null);

        // reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }

}
