using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPanel : MonoBehaviour
{
    private int currentWorldIndex;
    private int worldIndexProgressPanel;

    public Transform youAreThisBig;
    public GameObject AddOn;

    public GameObject signalHubObject;
    SignalHub signalHub;

    public GameObject progressPanel;

    public Transform[] youAreThisBigPos;

    private bool firstTime = true;
    void Start()
    {
        signalHub = signalHubObject.GetComponent<SignalHub>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWorldIndex = signalHub.currentWorldIndex;
        worldIndexProgressPanel = currentWorldIndex - 6;

        if((currentWorldIndex > 17 || currentWorldIndex < 15) && firstTime)
        {
            progressPanel.gameObject.SetActive(true);
            firstTime = false;
        }

        AddOn.transform.GetChild(worldIndexProgressPanel).gameObject.SetActive(true) ;
        youAreThisBig.position = youAreThisBigPos[worldIndexProgressPanel].position;
    }
}
