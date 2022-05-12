using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrototype3 : MonoBehaviour
{
    private Animation ani;

    public Transform entitiesHolder;

    private bool grow;
    private bool shrink;
    private bool isScaleAction;

    int entityIndex = 4;

    int numberOfVisableEntitiesHolder = 1;

    Vector3 newSmallEntityPosition = new Vector3(0.01f, 0.005f, 0);
    Vector3 newLargeEntityPosition = new Vector3(1000, 500, 0);

    //stacking position
    public Transform UIManagerT;
    //public GameObject UIManager;
    //public Transform visableHolder;
    private bool u01ORu1;

    //if stack 0.1u
    Vector3 newEntityPosition01u = new Vector3(0.1f, 0.05f, 0);
    Vector3 addYdis01u = new Vector3(0, 0.1f, 0);

    //if stack 1u
    Vector3 newEntityPosition1u = new Vector3(1f, 0.5f, 0);
    Vector3 addYdis1u = new Vector3(0, 1f, 0);

    //array to store positions and rotations of stacking
    //two dimension array, Vector3[7,9], 8 entities, 10 positions
    Vector3[,] stackingPos = {
        { new Vector3(0, 0.05f, 0),new Vector3(0, 0.15f, 0),new Vector3(0, 0.25f, 0), new Vector3(0, 0.35f, 0),new Vector3(0, 0.45f, 0),new Vector3(0, 0.55f, 0),new Vector3(0, 0.65f, 0),new Vector3(0, 0.75f, 0),new Vector3(0, 0.85f, 0),new Vector3(0, 0.95f, 0)},
        { new Vector3(0, 0.05f, 0),new Vector3(0, 0.15f, 0),new Vector3(0, 0.25f, 0), new Vector3(0, 0.35f, 0),new Vector3(0, 0.45f, 0),new Vector3(0, 0.55f, 0),new Vector3(0, 0.65f, 0),new Vector3(0, 0.75f, 0),new Vector3(0, 0.85f, 0),new Vector3(0, 0.95f, 0)},
        { new Vector3(0.3f, 0.05f, 0),new Vector3(0.3f, 0.15f, 0),new Vector3(0.3f, 0.25f, 0), new Vector3(0.3f, 0.35f, 0),new Vector3(0.3f, 0.45f, 0),new Vector3(0.3f, 0.55f, 0),new Vector3(0.3f, 0.65f, 0),new Vector3(0.3f, 0.75f, 0),new Vector3(0.3f, 0.85f, 0),new Vector3(0.3f, 0.95f, 0)},
        { new Vector3(0.8f, 0.5f, -0.5f),new Vector3(0.8f, 0.5f, -0.4f),new Vector3(0.8f, 0.5f, -0.3f), new Vector3(0.8f, 0.5f, -0.2f),new Vector3(0.8f, 0.5f, -0.1f),new Vector3(0.8f, 0.5f, 0),new Vector3(0.8f, 0.5f, 0.1f),new Vector3(0.8f, 0.5f, 0.2f),new Vector3(0.8f, 0.5f, 0.3f),new Vector3(0.8f, 0.5f, 0.4f)},
        { new Vector3(0.55f, 0.5f, 0), new Vector3(0.65f, 0.5f, 0),new Vector3(0.75f, 0.5f, 0),new Vector3(0.85f, 0.5f, 0),new Vector3(0.95f, 0.5f, 0),new Vector3(1.05f, 0.5f, 0),new Vector3(1.15f, 0.5f, 0),new Vector3(1.25f, 0.5f, 0),new Vector3(1.35f, 0.5f, 0),new Vector3(1.45f, 0.5f, 0)},
        { new Vector3(0, 0.05f, 0),new Vector3(0, 0.15f, 0),new Vector3(0, 0.25f, 0), new Vector3(-0.2f, 0.35f, 0),new Vector3( -0.1f, 0.45f, 0),new Vector3(0, 0.55f, 0),new Vector3(0, 0.65f, 0),new Vector3(0, 0.75f, 0),new Vector3(0, 0.85f, 0),new Vector3(0, 0.95f, 0)},
        { new Vector3(0, 0.05f, 0),new Vector3(0, 0.15f, 0),new Vector3(0, 0.25f, 0), new Vector3(0, 0.35f, 0),new Vector3(0, 0.45f, 0),new Vector3(0, 0.55f, 0),new Vector3(0, 0.65f, 0),new Vector3(0, 0.75f, 0),new Vector3(0, 0.85f, 0),new Vector3(0, 0.95f, 0)},
        { new Vector3(0, 0.05f, 0),new Vector3(0, 0.15f, 0),new Vector3(0, 0.25f, 0), new Vector3(0, 0.35f, 0),new Vector3(0, 0.45f, 0),new Vector3(0, 0.55f, 0),new Vector3(0, 0.65f, 0),new Vector3(0, 0.75f, 0),new Vector3(0, 0.85f, 0),new Vector3(0, 0.95f, 0)}

        };
    //two dimension array, Vector3[7,9], 8 entities, 10 rotations
    Vector3[,] stackingRot = {
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0), new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0),new Vector3(0, 90, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)},
        { new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0), new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0),new Vector3(0, 0, 0)}

        };

    void Start()
    {

    }

    void Update()
    {
        //ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();

        if (Input.GetKeyDown(KeyCode.D) && (!isScaleAction))
        {
            if (entityIndex == 2)
            {
                print("no more scale down");
            }
            else
            {
                //get the small entity from the EntitiesHolder
                GameObject newSmallEntityPre = entitiesHolder.GetChild(entityIndex - 3).GetChild(0).gameObject;
                
                //Instantiate the small entity
                GameObject newSmallEntity = Instantiate(newSmallEntityPre, newSmallEntityPosition, Quaternion.identity);

                //attach the small entity to the first (not default)
                newSmallEntity.transform.parent = transform.GetChild(0).transform;
                newSmallEntity.transform.SetAsFirstSibling();

                ani = transform.GetChild(0).GetComponent<Animation>();
                ani.Play("grow");

                grow = true;
                isScaleAction = true;

                //Instantiate the NewVisableEntitiesHolder
                GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("NewVisableEntitiesHolder");
                GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

                //numberOfVisableEntitiesHolder++;

                //attach the NewVisableEntitiesHolder to VisableHolder
                newVisableEntitiesHolder.transform.parent = transform;

                entityIndex--;
                print(entityIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && (!isScaleAction))
        {
            if (entityIndex == 14)
            {
                print("no more scale up");
            }
            else
            {
                //get the large entity from the EntitiesHolder
                GameObject newLargeEntityPre = entitiesHolder.GetChild(entityIndex + 2).GetChild(1).gameObject;

                //Instantiate the large entity
                GameObject newLargeEntity = Instantiate(newLargeEntityPre, newLargeEntityPosition, Quaternion.identity);

                //attach the large entity to the last (default)
                newLargeEntity.transform.parent = transform.GetChild(0).transform;

                ani = transform.GetChild(0).GetComponent<Animation>();
                ani.Play("shrink");

                shrink = true;
                isScaleAction = true;

                //Instantiate the NewVisableEntitiesHolder
                GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("NewVisableEntitiesHolder");
                GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

                //numberOfVisableEntitiesHolder++;

                //attach the NewVisableEntitiesHolder to VisableHolder
                newVisableEntitiesHolder.transform.parent = transform;

                entityIndex++;
                print(entityIndex);
            }
        }

        if (isScaleAction && (!ani.IsPlaying("grow") && !ani.IsPlaying("shrink")))
        {
            //move all the Entities to the NewVisableEntitiesHolder
            for (int i = 0; i < 5; i++)
            {
                transform.GetChild(0).GetChild(0).transform.parent =
                transform.GetChild(1).transform;
            }
            
            //destroy the old VisableEntitiesHolder
            DestroyImmediate(transform.GetChild(0).gameObject);

            isScaleAction = false;

            if (grow)
            {
                //destroy E5
                DestroyImmediate(transform.GetChild(0).GetChild(4).gameObject);

                grow = false;
            }

            if (shrink)
            {
                //destroy E1
                DestroyImmediate(transform.GetChild(0).GetChild(0).gameObject);
                         
                shrink = false;
            }
        }

        //stacking
        //stack01u
        if (Input.GetKeyDown(KeyCode.N))
        {
            u01ORu1 = true;

            //hide P1Holder
            transform.GetChild(numberOfVisableEntitiesHolder - 1).GetChild(0).GetChild(1).gameObject.SetActive(false);

            GameObject newStackingHolderPre = Resources.Load<GameObject>("NewStackingHolder");
            GameObject newStackingHolder = Instantiate(newStackingHolderPre, transform.position, Quaternion.identity);
            newStackingHolder.transform.parent = UIManagerT;
            StartCoroutine(ExecuteAfterTime01u(0.5f));
        }
        //stack1u
        if (Input.GetKeyDown(KeyCode.M))
        {
            u01ORu1 = false;

            //hide P2Holder
            transform.GetChild(numberOfVisableEntitiesHolder - 1).GetChild(0).GetChild(2).gameObject.SetActive(false);

            GameObject newStackingHolderPre = Resources.Load<GameObject>("NewStackingHolder");
            GameObject newStackingHolder = Instantiate(newStackingHolderPre, transform.position, Quaternion.identity);
            newStackingHolder.transform.parent = UIManagerT;
            StartCoroutine(ExecuteAfterTime1u(0.5f));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(UIManagerT.GetChild(0).gameObject);
            if (u01ORu1)
            {
                transform.GetChild(numberOfVisableEntitiesHolder - 1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(numberOfVisableEntitiesHolder - 1).GetChild(0).GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ExecuteAfterTime01u(float time)
    {
        GameObject newEntityPre = entitiesHolder.GetChild(entityIndex - 2).GetChild(2).gameObject;
        //newEntityPre.transform.Rotate(Vector3.forward, 45);
        //yield return new WaitForSeconds(time);

        /*
        for (int i = 1; i < 10; i++)
        {
            //GameObject newEntityPre = visableHolder.GetChild(0).GetChild(0).GetChild(entityIndex).gameObject;
            GameObject newEntity = Instantiate(newEntityPre, newEntityPosition01u + addYdis01u * i, newEntityPre.transform.rotation);
            newEntity.transform.parent = UIManagerT.GetChild(0).transform;

            yield return new WaitForSeconds(time);
        }
        */

        for (int i = 1; i < 11; i++)
        {
            //GameObject newEntityPre = visableHolder.GetChild(0).GetChild(0).GetChild(entityIndex).gameObject;
            GameObject newEntity = Instantiate(newEntityPre, stackingPos[entityIndex - 2, i - 1], Quaternion.Euler(stackingRot[entityIndex - 2, i - 1]));
            newEntity.transform.parent = UIManagerT.GetChild(0).transform;

            yield return new WaitForSeconds(time);
        }

    }
    IEnumerator ExecuteAfterTime1u(float time)
    {

        GameObject newEntityPre = entitiesHolder.GetChild(entityIndex - 1).GetChild(3).gameObject;
        //newEntityPre.transform.Rotate(Vector3.forward, 45);
        //yield return new WaitForSeconds(time);

        for (int i = 1; i < 10; i++)
        {
            //GameObject newEntityPre = visableHolder.GetChild(0).GetChild(0).GetChild(entityIndex).gameObject;
            GameObject newEntity = Instantiate(newEntityPre, newEntityPosition1u + addYdis1u * i, newEntityPre.transform.rotation);
            newEntity.transform.parent = UIManagerT.GetChild(0).transform;

            yield return new WaitForSeconds(time);
        }
    }
}
