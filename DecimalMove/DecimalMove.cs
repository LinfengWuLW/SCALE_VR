using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecimalMove : MonoBehaviour
{
    public int indexDecimal=25;
    int numberOfVisableEntitiesHolder = 1;

    //private int positiveIndex=10;
    //private int negativeIndex = 1;
    private int dummyHolders = 1;  //1-13:4; 1-21:12
    private int posDecimal = 42;

    private Animation ani;

    private bool isScaleAction;
    private bool isRight;
    private bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //print(indexDecimal);
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("Decimal2Right");

            isScaleAction = true;
            isRight = true;

            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("DecimalMoveAniHolder");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

            //numberOfVisableEntitiesHolder++;

            newVisableEntitiesHolder.transform.parent = transform;

            indexDecimal++;

            //positiveIndex++;

            dummyHolders--;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //print(indexDecimal);
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("Decimal2Left");

            isScaleAction = true;
            isLeft = true;

            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("DecimalMoveAniHolder");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

            //numberOfVisableEntitiesHolder++;

            newVisableEntitiesHolder.transform.parent = transform;

            indexDecimal--;

            //positiveIndex++;

            dummyHolders++;
        }

        if (isScaleAction && (!ani.IsPlaying("Decimal2Right") && !ani.IsPlaying("Decimal2Left")))
        {

            //print(numberOfVisableEntitiesHolder);
            //transform.GetChild(numberOfVisableEntitiesHolder - 2).GetChild(0).transform.parent = transform.GetChild(numberOfVisableEntitiesHolder - 1).transform;

            //tried. but did not clear the warning.
            //transform.GetChild(numberOfVisableEntitiesHolder - 2).GetChild(0).transform.SetParent(transform.GetChild(numberOfVisableEntitiesHolder - 1).transform) ;

            //Destroy(transform.GetChild(0).gameObject);
            if (isRight)
            {
                for (int i = dummyHolders; i < (dummyHolders + 30); i++)
                {
                    //print(i);
                    transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i - 1).transform;
                }

                isRight = false;
            }

            if (isLeft)
            {
                for (int i = dummyHolders; i < (dummyHolders + 30); i++)
                {
                    //print(i);
                    transform.GetChild(0).GetChild(0).GetChild(i-2).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i-1).transform;
                }

                isLeft = false;
            }

            transform.GetChild(0).GetChild(0).GetChild(posDecimal).GetChild(0).transform.parent =
            transform.GetChild(1).GetChild(0).GetChild(posDecimal).transform;

            Destroy(transform.GetChild(0).gameObject);

            isScaleAction = false;


        }

    }


}
