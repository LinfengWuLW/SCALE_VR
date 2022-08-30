using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HomeManager : MonoBehaviour
{


    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;

    private bool m_IsTeleporting = false;
    private float m_FadeTime = 0.5f;

    private Vector3 homePosition = new Vector3(0, 0, 0);

    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean home_ClickAction;

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Update()
    {
        if (home_ClickAction.GetStateDown(m_TargetSource))
        {
            TryTeleport();
        }
    }

    private void TryTeleport()
    {  
        // get camera rig, and head position
        Transform cameraRig = SteamVR_Render.Top().origin;
        Vector3 headPosition = SteamVR_Render.Top().head.position;

        // figure out translation
        Vector3 groundPosition = new Vector3(headPosition.x, cameraRig.position.y, headPosition.z);
        //Vector3 translateVector = m_Pointer.transform.position - groundPosition;
        Vector3 translateVector = homePosition - groundPosition;

        // move
        StartCoroutine(MoveRig(cameraRig, translateVector));
    }

    private IEnumerator MoveRig(Transform cameraGig, Vector3 translation)
    {
        // flag
        m_IsTeleporting = true;

        // fade to black
        SteamVR_Fade.Start(Color.black, m_FadeTime, true);

        // apply translation
        yield return new WaitForSeconds(m_FadeTime);
        cameraGig.position += translation;

        // fade to clear
        SteamVR_Fade.Start(Color.clear, m_FadeTime, true);

        // de-flag
        m_IsTeleporting = false;

    }
}
