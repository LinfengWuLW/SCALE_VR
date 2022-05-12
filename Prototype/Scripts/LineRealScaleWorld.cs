using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRealScaleWorld : MonoBehaviour
{
    public Transform pathHolder;

    public float moveSpeed = 0.1f;
    public float scaleSpeed = 1f;

    int targetPositionIndex = 0;

    IEnumerator currentMoveCoroutine;

    private Animation ani;

    //private bool grow;

    private float currentScaleIndex;

    //private float targetScale;

    Vector3 targetScale = new Vector3().normalized;

    void Start()
    {
        ani = GetComponent<Animation>();
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

                //grow = false;

                print(targetPositionIndex);
                print(wayPoints[targetPositionIndex]);

                //ani.Play("shrink");

                //print(currentScale);
                print(transform.localScale);
                print(transform.lossyScale);

                //if (currentMoveCoroutine != null)
                //{
                // StopCoroutine(currentMoveCoroutine);
                //}

                currentMoveCoroutine = Move(wayPoints[targetPositionIndex], moveSpeed);
                StartCoroutine(currentMoveCoroutine);

                StartCoroutine(Scale(targetScale));

                //transform.localScale = transform.localScale * 0.1f * Mathf.Lerp(10, 1, Time.deltaTime*scaleSpeed) ;



                //currentScale = transform.localScale;

                //print(currentScale);
                print(transform.localScale);
                print(transform.lossyScale);

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

                // grow = true;

                print(targetPositionIndex);
                print(wayPoints[targetPositionIndex]);

                //ani.Play("grow");

                //if (currentMoveCoroutine != null)
                //{
                //StopCoroutine(currentMoveCoroutine);
                //}

                currentMoveCoroutine = Move(wayPoints[targetPositionIndex], moveSpeed);
                StartCoroutine(currentMoveCoroutine);

                //StartCoroutine(Scale(10f, scaleSpeed));
            }
        }
    }

    IEnumerator Move(Vector3 destination, float moveSpeed)
    {
        while (transform.position != destination)
        {
            //if(grow)
            //{
            //ani.Play("grow");
            //}
            //else { ani.Play("shrink"); }



            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            //transform.localScale = Vector3.MoveTowards(transform.localScale, targeScale, scaleSpeed * Time.deltaTime);

            yield return null;




        }
    }

    IEnumerator Scale(Vector3 targetScale)
    {
        while (transform.localScale != targetScale)
        {
            //transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

            transform.localScale = transform.localScale * 0.1f * Mathf.Lerp(10, 1, Time.deltaTime * scaleSpeed);
            targetScale = transform.localScale;

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
