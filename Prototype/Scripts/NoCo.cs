using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCo : MonoBehaviour
{
    //start this script thinking about using no coroutine; but instead using coroutine.
    //and it worked.
    

    public Transform pathHolder;

    //public float moveSpeed = 0.01f;
    float[] moveSpeed = { 1,0.1f,0.01f,0.001f ,0.0001f};
    float[] scaleSpeed= { 1, 0.1f, 0.01f, 0.001f, 0.0001f };

    int moveSpeedIndex=0;
    int scaleSpeedIndex = 0;

    //public float scaleSpeed = 0.01f;

    int targetPositionIndex = 0;

    Vector3 targetScale = new Vector3(1, 1, 1);

    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Vector3[] wayPoints = GetWayPoints();

        if (Input.GetMouseButtonDown(0))
        {

            if (targetPositionIndex == 4)
            {
                print("no more shrink");
            }
            else
            {
                targetPositionIndex++;

                targetScale = targetScale / 10;

                scaleSpeedIndex++;

                StartCoroutine( Scale(targetScale, scaleSpeed[scaleSpeedIndex - 1]));

                //Move(wayPoints[targetPositionIndex], moveSpeed);

                moveSpeedIndex++;
                print(moveSpeedIndex);
                print(moveSpeed[moveSpeedIndex]);
                StartCoroutine(Move(wayPoints[targetPositionIndex], moveSpeed[moveSpeedIndex-1]));
            }
        }

        if (Input.GetMouseButtonDown(1))
        {

            if (targetPositionIndex == 0)
            {
                print("no more grow");
            }
            else
            {
                targetPositionIndex--;

                targetScale = targetScale * 10;

                scaleSpeedIndex--;

                Scale(targetScale, scaleSpeed[moveSpeedIndex]);

                //Move(wayPoints[targetPositionIndex], moveSpeed);

                moveSpeedIndex--;
                StartCoroutine(Move(wayPoints[targetPositionIndex], moveSpeed[moveSpeedIndex]));
            }
        }
    }

    IEnumerator Move(Vector3 destination, float moveSpeed)
    {
        while (transform.position != destination)
        {
            
            yield return StartCoroutine(Scale(targetScale, scaleSpeed[moveSpeedIndex]));
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            
        }
    }

    IEnumerator Scale(Vector3 targetScale,float scaleSpeed)
    {
        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
            yield return null;
        }

    }

    Vector3[] GetWayPoints()
    {
        Vector3[] wayPoints = new Vector3[pathHolder.childCount];
        //print(standingPositions.childCount);
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = pathHolder.GetChild(i).position;
        }
        return wayPoints;
    }
}
