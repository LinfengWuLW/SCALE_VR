using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform CamTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //point1
        /*if (CamTransform.position.x >= 9.5f && CamTransform.position.x <= 10.5f && CamTransform.position.z >= -10.5f && CamTransform.position.z <= -9.5f)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {           
            transform.GetChild(0).gameObject.SetActive(true);         
        }*/
        //point2
        if (CamTransform.position.x >= 0.5f && CamTransform.position.x <= 1.5f && CamTransform.position.z >= -9.5f && CamTransform.position.z <= -8.5f)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }

        //point4
        /*if(CamTransform.position.x>=-1.5f && CamTransform.position.x <= -0.5f && CamTransform.position.z >= -0.5f && CamTransform.position.z <= 0.5f)
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
        else
        {           
            transform.GetChild(3).gameObject.SetActive(true);
        }
        //point5
        if (CamTransform.position.x >= 2.5f && CamTransform.position.x <= 3.5f && CamTransform.position.z >= -3.5f && CamTransform.position.z <= -2.5f)
        {
            transform.GetChild(4).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
        */
        //point6
        if (CamTransform.position.x >= 1.5f && CamTransform.position.x <= 2.5f && CamTransform.position.z >= -2.5f && CamTransform.position.z <= -1.5f)
        {
            transform.GetChild(5).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(5).gameObject.SetActive(true);
        }
        //point7
        if (CamTransform.position.x >= -0.5f && CamTransform.position.x <= 0.5f && CamTransform.position.z >= -0.5f && CamTransform.position.z <= 0.5f)
        {
            transform.GetChild(6).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(6).gameObject.SetActive(true);
        }     
    }
}
