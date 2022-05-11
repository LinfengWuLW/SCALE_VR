using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressPanel : MonoBehaviour
{
    public int worldIndex=3;
    public Transform youAreThisBig;
    public GameObject AddOnLines;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddOnLines.transform.GetChild(worldIndex-1).gameObject.SetActive(true);
            worldIndex--;
            youAreThisBig.transform.position = new Vector2(youAreThisBig.transform.position.x - 0.95f, youAreThisBig.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            AddOnLines.transform.GetChild(worldIndex).gameObject.SetActive(true);
            worldIndex++;
            youAreThisBig.transform.position = new Vector2(youAreThisBig.transform.position.x + 0.95f, youAreThisBig.transform.position.y);
        }
    }
}
