using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingTest : MonoBehaviour
{
    //public Transform entitiesHolder;
    public Transform visableHolder;
    int entityIndex=1;
    Vector3 newEntityPosition = new Vector3(0.1f, 0.05f, 0);
    Vector3 addYdis = new Vector3(0, 0.11f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnButtonPress()
    {

        Debug.Log("Button clicked ");

        StartCoroutine(ExecuteAfterTime(0.5f));

        IEnumerator ExecuteAfterTime(float time)
        {

            GameObject newEntityPre = visableHolder.GetChild(0).GetChild(0).GetChild(entityIndex).gameObject;
            newEntityPre.transform.Rotate(Vector3.forward, 45);
            
            yield return new WaitForSeconds(time);

            for (int i = 1; i < 10; i++)
            {
                //GameObject newEntityPre = visableHolder.GetChild(0).GetChild(0).GetChild(entityIndex).gameObject;
                GameObject newEntity = Instantiate(newEntityPre, newEntityPosition + addYdis * i, newEntityPre.transform.rotation);
                yield return new WaitForSeconds(time);
            }

            
        }

       
    }

}
