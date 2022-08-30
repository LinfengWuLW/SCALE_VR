using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleport_W : MonoBehaviour
{

    public GameObject m_Pointer;
    public SteamVR_Action_Boolean m_TeleportAction;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool m_HasPosition = false;

    private bool m_IsTeleporting = false;
    private float m_FadeTime = 0.5f;
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    void Update()
    {
        //pointer
        m_HasPosition = UpdatePointer();
        m_Pointer.SetActive(m_HasPosition);

        //Teleport
        if (m_TeleportAction.GetStateUp(m_Pose.inputSource))
            TryTeleport();
    }

    private void TryTeleport()
    {
        // check for valid position, and if already teleporting
        if (!m_HasPosition || m_IsTeleporting)
            return;
        // get camera rig, and head position
        Transform cameraRig = SteamVR_Render.Top().origin;
        Vector3 headPosition = SteamVR_Render.Top().head.position;

        // figure out translation
        Vector3 groundPosition = new Vector3(headPosition.x, cameraRig.position.y, headPosition.z);
        Vector3 translateVector = m_Pointer.transform.position - groundPosition;

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

    private bool UpdatePointer()
    {
        // ray from the controller
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // if it's a hit
        if (Physics.Raycast(ray, out hit) )
        {
            if (hit.collider.tag == "teleportPoint")
            {
                m_Pointer.transform.position = hit.point;
                return true;
            }
        }

        // if not a hit
        return false;
    }
}
