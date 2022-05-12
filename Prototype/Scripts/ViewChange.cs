using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChange : MonoBehaviour
{

    public Transform standingPositions;

    int targetPositionIndex = 0;

    Vector3[] standPoints= new Vector3[3];
    //Vector3[] standPoints;

    Vector3 targetPosition=Vector3.zero;

    public float speed=5;
    void Start()
    {
        Vector3[] standPoints = new Vector3[standingPositions.childCount];
        //print(standingPositions.childCount);
        for (int i = 0; i < standPoints.Length; i++)
        {
            standPoints[i] = standingPositions.GetChild(i).position;
        }

        transform.position = standPoints[0];
    }

    Vector3[] getStandPoints()
    {
        Vector3[] standPoints = new Vector3[standingPositions.childCount];
        //print(standingPositions.childCount);
        for (int i = 0; i < standPoints.Length; i++)
        {
            standPoints[i] = standingPositions.GetChild(i).position;
        }
        return standPoints;
    }

    void Update()
    {
        //Vector3[] standPoints = new Vector3[standingPositions.childCount];

        Vector3[] standPoints = getStandPoints();


        if (Input.GetMouseButtonDown(0))
        {
            if (targetPositionIndex == 0)
            {
                print("no more shrink");
            }
            else
            {
                targetPositionIndex = targetPositionIndex - 1;
                print(targetPositionIndex);

                targetPosition = standPoints[targetPositionIndex];
                print(targetPosition);

                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                //Vector3 moveDirection = targetPosition - transform.position;
                //transform.Translate(moveDirection, Space.World);

                transform.position = targetPosition;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (targetPositionIndex == 2)
            {
                print("no more grow");
            }
            else
            {
                targetPositionIndex = targetPositionIndex + 1;
                print(targetPositionIndex);

                targetPosition = standPoints[targetPositionIndex];
                print(targetPosition);

                //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                //Vector3 moveDirection = targetPosition - transform.position;
                //transform.Translate(moveDirection, Space.World);

                transform.position = targetPosition;
            }
        }
    }
}
