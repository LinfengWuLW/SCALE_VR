using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMotionColliderManager : MonoBehaviour
{
    public GameObject handMotionCollider;
    // B: allow only buttons
    //H: also allow hand motion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            handMotionCollider.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            handMotionCollider.SetActive(true);
        }
    }
}
