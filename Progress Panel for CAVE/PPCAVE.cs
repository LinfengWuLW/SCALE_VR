using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPCAVE : MonoBehaviour
{
    
    public int currentWorldIndex=16;

    public int leftVisited = 16;
    public int rightVisited = 16;

    public int leftVisible=14;
    public int rightVisible = 18;

    public int ppLineLeft = 14;
    public int ppLineRight = 18;

    public int ppIconLeft = 16;
    public int ppIconRight = 16;

    public int leftLimit = 11;
    public int rightLimit = 21;

    public float lineMoveDistance = 0.95f;
    public float iconMoveDistance = 0.95f;
    public float numberMoveDistance = 47.5f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if (currentWorldIndex+2 < rightLimit)
            {
                ScaleUpNewIndex();
                DrawPP();
                MoveDistanceLeft();
            }                 
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if (currentWorldIndex-2 > leftLimit)
            {
                ScaleDownNewIndex();
                DrawPP();
                MoveDistanceRight();
            }
        }
    }

    private void ScaleUpNewIndex()
    {
        currentWorldIndex++;

        rightVisited = Mathf.Max(currentWorldIndex, rightVisited);
        rightVisible = Mathf.Max(currentWorldIndex + 2, rightVisible);

        ppLineRight = Mathf.Min(rightVisible, currentWorldIndex + 5);
        ppIconRight = Mathf.Min(rightVisited, currentWorldIndex + 5);

        ppLineLeft = Mathf.Max(leftVisible, currentWorldIndex - 5);
        ppIconLeft = Mathf.Max(leftVisited, currentWorldIndex - 5);

        //right dot show
    }
    private void ScaleDownNewIndex()
    {
        currentWorldIndex--;

        leftVisited= Mathf.Min(currentWorldIndex , leftVisited );
        leftVisible = Mathf.Min(currentWorldIndex - 2 , leftVisible );

        ppLineLeft = Mathf.Max( leftVisible , currentWorldIndex - 5 );
        ppIconLeft = Mathf.Max(leftVisited, currentWorldIndex - 5);

        ppLineRight = Mathf.Min( rightVisible , currentWorldIndex + 5) ;
        ppIconRight = Mathf.Min(rightVisited , currentWorldIndex + 5 );

        //right dot show
       
    }
    private void DrawPP()
    {
        for(int i=1;i<=3;i++)
        {
            for(int j=0;j<=10;j++)
            {
                this.transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
            }
        }
        for (int j = 0; j <= 1; j++)
        {
            this.transform.GetChild(4).GetChild(j).gameObject.SetActive(false);
        }

        //show lines
        for (int i = ppLineLeft; i <= ppLineRight; i++)
            this.transform.GetChild(1).GetChild(i - 11).gameObject.SetActive(true);

        //show icons
        for (int i = ppIconLeft; i <= ppIconRight; i++)
            this.transform.GetChild(2).GetChild(i - 11).gameObject.SetActive(true);

        //show numbers
        for (int i = ppIconLeft; i <= ppIconRight; i++)
            this.transform.GetChild(3).GetChild(i - 11).gameObject.SetActive(true);

        //show dots
        if(currentWorldIndex-leftVisible>5)
        {
            this.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        }
        if (rightVisible - currentWorldIndex > 5)
        {
            this.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
        }
    }

    private void MoveDistanceLeft()
    {
        this.transform.GetChild(1).transform.position =
                new Vector3(this.transform.GetChild(1).transform.position.x - lineMoveDistance,
                this.transform.GetChild(1).transform.position.y,
                this.transform.GetChild(1).transform.position.z);
        this.transform.GetChild(2).transform.position =
            new Vector3(this.transform.GetChild(2).transform.position.x - iconMoveDistance,
            this.transform.GetChild(2).transform.position.y,
            this.transform.GetChild(2).transform.position.z);
        this.transform.GetChild(3).transform.position =
           new Vector3(this.transform.GetChild(3).transform.position.x - numberMoveDistance,
           this.transform.GetChild(3).transform.position.y,
           this.transform.GetChild(3).transform.position.z);
    }
    private void MoveDistanceRight()
    {
        this.transform.GetChild(1).transform.position =
                new Vector3(this.transform.GetChild(1).transform.position.x + lineMoveDistance,
                this.transform.GetChild(1).transform.position.y,
                this.transform.GetChild(1).transform.position.z);
        this.transform.GetChild(2).transform.position =
            new Vector3(this.transform.GetChild(2).transform.position.x + iconMoveDistance,
            this.transform.GetChild(2).transform.position.y,
            this.transform.GetChild(2).transform.position.z);
        this.transform.GetChild(3).transform.position =
           new Vector3(this.transform.GetChild(3).transform.position.x + numberMoveDistance,
           this.transform.GetChild(3).transform.position.y,
           this.transform.GetChild(3).transform.position.z);
    }
}
