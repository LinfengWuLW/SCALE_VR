using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecimalMove_S : MonoBehaviour
{
    public int indexDecimal=10;//a number larger than 6
    int numberOfVisableEntitiesHolder = 1;

    //private int positiveIndex=10;
    //private int negativeIndex = 1;
    public int dummyHolders = 6;  //1-13:4; 1-21:12 ??????

    //index of decimal holder
    public int posDecimal = 24;

    private Animation ani;
    //private Animator anitor;

    private bool isScaleAction;
    private bool isRight;
    private bool isLeft;
    private bool isUnitRight;
    private bool isUnitLeft;

    //get the signal from the controller
    public GameObject HMDInputObeject;
    HMDInputModule vrpnInput;
    //this is not working;a bad way.the signal from the controller is set to false when it is used by the exponent. the order is difficult to control.
    //so try to get the signal from the exponent.
    //still not good.
    //should get the signal from the controller, but seperate from the other signals.

    public GameObject exponentScriptObeject;
    UIManager uiManager;

    private bool scaleUpC = false;
    private bool scaleDownC = false;

    private bool scaleUpFromExponent = false;
    private bool scaleDownFromEXponent = false;

    private bool unitRightC = false;
    private bool unitLeftC = false;

    //practical unit change
    //assume that we start from human world. -15~+15. we cannot have negative index. so 1~31. human world in the middle as index=16;
    public int currentWorldIndex=16;

    public bool signalFromDecimalRight2UnitChange;
    public bool signalFromDecimalLeft2UnitChange;
    public bool signalFromDecimal2UnitChange;

    public GameObject signalHubObject;
    SignalHub signalHub;

    // Start is called before the first frame update
    void Start()
    {
        vrpnInput = HMDInputObeject.GetComponent<HMDInputModule>();

        uiManager = exponentScriptObeject.GetComponent<UIManager>();

        signalHub = signalHubObject.GetComponent<SignalHub>();
    }

    // Update is called once per frame
    void Update()
    {
        //scaleUpFromExponent = uiManager.scaleUpUI;
        //uiManager.scaleUpUI = false;
        //scaleDownFromEXponent = uiManager.scaleDownUI;
        //uiManager.scaleUpUI = false;

        scaleUpC = vrpnInput.scaleUpC2Decimal|vrpnInput.scaleUpHandMotion2Decimal;
        vrpnInput.scaleUpC2Decimal = false;
        //vrpnInput.scaleUpHandMotion2Decimal = false;

        scaleDownC = vrpnInput.scaleDownC2Decimal|vrpnInput.scaleDownHandMotion2Decimal;
        vrpnInput.scaleDownC = false;
        //vrpnInput.scaleDownHandMotion2Decimal = false;

        unitRightC = vrpnInput.unitChangeRightC2UnitChangePanel;
        vrpnInput.unitChangeRightC2UnitChangePanel = false;

        unitLeftC = vrpnInput.unitChangeLeftC2UnitChangePanel;
        vrpnInput.unitChangeLeftC2UnitChangePanel = false;

        if (signalHub.upSignalFromHub2Dec && !isScaleAction)//this is for simultaneous
        //if ( (signalHub.upSignalFromHub2Dec || signalHub.upSignalFromExp2Dec) && !isScaleAction)//this is for staggered animation
        //if ( (Input.GetKeyDown(KeyCode.R) || scaleUpC || scaleUpFromExponent) && !isScaleAction)
        {
            signalHub.decimalRightAniDone = false;
            signalHub.upSignalFromExp2Dec = false;
            signalHub.upSignalFromHub2Dec = false;
            scaleUpC = false;
            vrpnInput.scaleUpC2Decimal = false;

            scaleUpFromExponent = false;

            //print(indexDecimal);
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("Decimal2Right");

            print("DECIMALRIGHT");

            isScaleAction = true;
            isRight = true;


            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("StandNotationAni");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

            //numberOfVisableEntitiesHolder++;

            newVisableEntitiesHolder.transform.parent = transform;

            indexDecimal++;

            //positiveIndex++;

            dummyHolders--;

            currentWorldIndex++;
            
        }
        
        if ((Input.GetKeyDown(KeyCode.W) || unitRightC) && !isScaleAction)
        {
            unitRightC = false;
            indexDecimal =indexDecimal+3;
            dummyHolders = dummyHolders - 3;
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("UnitChangeRight");
            isScaleAction = true;

            isUnitRight = true;

            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("StandNotationAni");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);
            newVisableEntitiesHolder.transform.parent = transform;

            //print("create sucess");
        }
        
        if ((Input.GetKeyDown(KeyCode.Q) || unitLeftC) && !isScaleAction)
        {
            unitLeftC = false;
            indexDecimal = indexDecimal - 3;
            dummyHolders = dummyHolders + 3;
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("UnitChangeLeft");
            isScaleAction = true;

            isUnitLeft = true;

            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("StandNotationAni");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);
            newVisableEntitiesHolder.transform.parent = transform;
        }

        if (signalHub.downSignalFromHub2Dec && !isScaleAction)//this is for simultaneous
        //if ((signalHub.downSignalFromHub2Dec || signalHub.downSignalFromExp2Dec) && !isScaleAction)//this is for staggered animation
        //if ( (Input.GetKeyDown(KeyCode.L) || scaleDownC || scaleDownFromEXponent) && !isScaleAction)
        {
            signalHub.decimalLeftAniDone = false;
            signalHub.downSignalFromExp2Dec = false;
            signalHub.downSignalFromHub2Dec = false;

            signalHub.decimalLeftAniDone = false;
            scaleDownC = false;
            vrpnInput.scaleDownC2Decimal = false;

            scaleDownFromEXponent = false;

            //print(indexDecimal);
            ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
            ani.Play("Decimal2Left");

            isScaleAction = true;
            isLeft = true;

            GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("StandNotationAni");
            GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

            //numberOfVisableEntitiesHolder++;

            newVisableEntitiesHolder.transform.parent = transform;

            indexDecimal--;

            //positiveIndex++;

            dummyHolders++;

            currentWorldIndex--;
        }

        if (isScaleAction && (!ani.IsPlaying("Decimal2Right") && !ani.IsPlaying("Decimal2Left") && !ani.IsPlaying("UnitChangeRight") && !ani.IsPlaying("UnitChangeLeft")))
        {

            //print(numberOfVisableEntitiesHolder);
            //transform.GetChild(numberOfVisableEntitiesHolder - 2).GetChild(0).transform.parent = transform.GetChild(numberOfVisableEntitiesHolder - 1).transform;

            //tried. but did not clear the warning.
            //transform.GetChild(numberOfVisableEntitiesHolder - 2).GetChild(0).transform.SetParent(transform.GetChild(numberOfVisableEntitiesHolder - 1).transform) ;

            //Destroy(transform.GetChild(0).gameObject);
            //decimal to right
            if (isRight)
            {
                for (int i = (dummyHolders+1); i < (dummyHolders + 13); i++)//had dummyHolders--, so +1 here
                {
                    //print(i);
                    //numbers move up along the holders
                    transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i - 1).transform;
                }

                isRight = false;

                signalFromDecimalRight2UnitChange = true;
                signalFromDecimalLeft2UnitChange = false;
            }
            //unit to right
            if (isUnitRight)
            {
                for (int i = (dummyHolders + 3); i < (dummyHolders + 15); i++)//had dummyHolders--, so +1 here
                {
                    print(i);
                    //numbers move up along the holders
                    transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i - 3).transform;
                }

                isUnitRight = false;
            }

            if (isLeft)
            {
                for (int i = (dummyHolders-1); i < (dummyHolders + 11); i++)//had dummyHolders++, so -1 here
                {
                    //print(i);
                    //numbers move down along the holders
                    transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i+1).transform;
                }

                isLeft = false;
                signalFromDecimalLeft2UnitChange = true;
                signalFromDecimalRight2UnitChange = false;
            }
            //unit to left
            if (isUnitLeft)
            {
                for (int i = (dummyHolders - 3); i < (dummyHolders + 9); i++)//had dummyHolders--, so +1 here
                {
                    print(i);
                    //numbers move up along the holders
                    transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
                    transform.GetChild(1).GetChild(0).GetChild(i + 3).transform;
                }

                isUnitLeft = false;
            }

            transform.GetChild(0).GetChild(0).GetChild(posDecimal).GetChild(0).transform.parent =
            transform.GetChild(1).GetChild(0).GetChild(posDecimal).transform;

            Destroy(transform.GetChild(0).gameObject);

            isScaleAction = false;

            signalFromDecimal2UnitChange = true;

            //try to fix the double click problem
            //set the signal to false after everything is done
            //so the scaling won't be triggered until next signal
            scaleDownC = false;
            scaleUpC = false;


            signalHub.decimalLeftAniDone = true;
            signalHub.decimalRightAniDone = true;
        }

    }


}
