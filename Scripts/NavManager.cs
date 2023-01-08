using UnityEngine;

public class NavManager : MonoBehaviour
{
    public GameObject NavPanelObeject;
    public GameObject StandNotationObeject;
    public Transform CamTransform;
    
    void Update()
    {
        if (CamTransform.position.x>0.5)
        {
            NavPanelObeject.SetActive(false);
            StandNotationObeject.SetActive(false);
        }
        else
        {
            NavPanelObeject.SetActive(true);
            StandNotationObeject.SetActive(true);
        }
    }
}
