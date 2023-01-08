using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingTest : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform visableHolder;
	int entity1uIndex=3;
	int entity01uIndex=2;

	Vector3 newEntityPosition1u=new Vector3(1,0,0);
	Vector3 newEntityPosition01u=new Vector3(0.1f,0,0);
    
	Vector3 addYdis1u=new Vector3(0,1,0);
	Vector3 addYdis01u=new Vector3(0,0.1f,0);

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//stacking 0.1u
		if ( (Input.GetKeyDown(KeyCode.N) ))
			{
				StartCoroutine(ExecuteAfterTime01u(0.5f));
			}
		//stacking 1u
		if ( (Input.GetKeyDown(KeyCode.M) ))
		{
			StartCoroutine(ExecuteAfterTime1u(0.5f));
		}

    }

	IEnumerator ExecuteAfterTime01u(float time)
	{
		GameObject newEntityPre=visableHolder.GetChild(0).GetChild(0).GetChild(entity01uIndex).GetChild(0).GetChild(0).GetChild(0).gameObject;

		//newEntityPre.transform.Rotate();
		for (int i=1;i<10;i++)
		{
			GameObject newEntity=Instantiate(newEntityPre, newEntityPosition01u+addYdis01u*i,newEntityPre.transform.rotation);
			yield return new WaitForSeconds(time);
		}
	}
	IEnumerator ExecuteAfterTime1u(float time)
	{
		GameObject newEntityPre=visableHolder.GetChild(0).GetChild(0).GetChild(entity1uIndex).GetChild(0).GetChild(0).GetChild(0).gameObject;
		//newEntityPre.transform.Rotate();
		for (int i=1;i<10;i++)
		{
			GameObject newEntity=Instantiate(newEntityPre, newEntityPosition1u+addYdis1u*i,newEntityPre.transform.rotation);
			yield return new WaitForSeconds(time);
		}
	}
}
