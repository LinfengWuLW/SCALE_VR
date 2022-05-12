using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneViewChange : MonoBehaviour
{
    public Transform standingPositions;

    //int targetPositionIndex = 0;

    //Vector3[] standPoints = new Vector3[3];
    //Vector3[] standPoints;

    //Vector3 targetPosition = Vector3.zero;

     float[] speed = {30,1,10 };

    public float waitTime = .3f;
    void Start()
    {
        Vector3[] standPoints = new Vector3[standingPositions.childCount];
        //print(standingPositions.childCount);
        for (int i = 0; i < standPoints.Length; i++)
        {
            standPoints[i] = standingPositions.GetChild(i).position;
        }

        StartCoroutine(FollowPath(standPoints));

    }

    IEnumerator FollowPath(Vector3[] standPoints)
    {
        transform.position = standPoints[0];

        int targetStandPointIndex = 1;
        Vector3 targetStandPoint = standPoints[targetStandPointIndex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetStandPoint, speed[targetStandPointIndex] * Time.deltaTime);
            if (transform.position == targetStandPoint)
            {
                targetStandPointIndex = (targetStandPointIndex + 1) % standPoints.Length;
                targetStandPoint = standPoints[targetStandPointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }



    }
}
