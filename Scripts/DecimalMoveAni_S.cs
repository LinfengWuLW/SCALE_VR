using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecimalMoveAni_S : MonoBehaviour
{
    private int indexM2Holder=13;
    private int indexM1Holder = 12;
	private int indexM3Holder = 14;
	private int indexM4Holder = 15;

	private int index2Holder = 10;
    private int index1Holder = 11;

    private int indexDecimal;

    //the index number to record the starting point of the decimal as in 1.7
    //here let it equal to the indexDecimal
    private int index2LeftCoe = 10;

    public GameObject decimalScript;
    DecimalMove_S decimalMove;

    //public TextMeshProUGUI leftBoxText;
    //public TextMeshProUGUI rightBoxText;
	//public TextMeshProUGUI centerUnitText;

	private string[] unitNameForBox ={
						/*-15*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-14*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-13*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-12*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-11*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-10*/		"<font-weight=500>\u207B\u00B9\u2070</font-weight>",
						/*-9*/		"<font-weight=500>\u207B\u2079</font-weight>",
						/*-8*/		"<font-weight=500>\u207B\u2078</font-weight>",
						/*-7*/		"<font-weight=500>\u207B\u2077</font-weight>",
						/*-6*/		"<font-weight=500>\u207B\u2076</font-weight>",
						/*-5*/		"<font-weight=500>\u207B\u2075</font-weight>",
						/*-4*/		"<font-weight=500>\u207B\u2074</font-weight>",
						/*-3*/		"<font-weight=500>\u207B\u00B3</font-weight>",
						/*-2*/		"<font-weight=500>\u207B\u00B2</font-weight>",
						/*-1*/		"<font-weight=500>\u207B\u00B9</font-weight>",
						/*0*/		"<font-weight=500>\u2070</font-weight>",
						/*1*/		"<font-weight=500>\u00B9</font-weight>",
						/*2*/		"<font-weight=500>\u00B2</font-weight>",
						/*3*/		"<font-weight=500>\u00B3</font-weight>",
						/*4*/		"<font-weight=500>\u2074</font-weight>",
						/*5*/		"<font-weight=500>\u2075</font-weight>",
						/*6*/		"<font-weight=500>\u2076</font-weight>",
						/*7*/		"<font-weight=500>\u2077</font-weight>",
						/*8*/		"<font-weight=500>\u2078</font-weight>",
						/*9*/		"<font-weight=500>\u2079</font-weight>",
						/*10*/		"<font-weight=500>\u00B9\u2070</font-weight>",
						/*11*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*12*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*13*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*14*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*15*/		"<font-weight=500>\u00B9\u00B9</font-weight>"
								};
	private string[] unitNameForCenterUnit ={
						/*-15*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-14*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-13*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-12*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-11*/		"<font-weight=500>\u207B\u00B9\u00B9</font-weight>",
						/*-10*/		"<font-weight=500>\u207B\u00B9\u2070</font-weight>",
						/*-9*/		"<font-weight=500>\u207B\u2079</font-weight>",
						/*-8*/		"<font-weight=500>\u207B\u2078</font-weight>",
						/*-7*/		"<font-weight=500>\u207B\u2077</font-weight>",
						/*-6*/		"<font-weight=500>\u207B\u2076</font-weight>",
						/*-5*/		"<font-weight=500>\u207B\u2075</font-weight>",
						/*-4*/		"<font-weight=500>\u207B\u2074</font-weight>",
						/*-3*/		"<font-weight=500>\u207B\u00B3</font-weight>",
						/*-2*/		"<font-weight=500>\u207B\u00B2</font-weight>",
						/*-1*/		"<font-weight=500>\u207B\u00B9</font-weight>",
						/*0*/		"<font-weight=500>\u2070</font-weight>",
						/*1*/		"<font-weight=500>\u00B9</font-weight>",
						/*2*/		"<font-weight=500>\u00B2</font-weight>",
						/*3*/		"<font-weight=500>\u00B3</font-weight>",
						/*4*/		"<font-weight=500>\u2074</font-weight>",
						/*5*/		"<font-weight=500>\u2075</font-weight>",
						/*6*/		"<font-weight=500>\u2076</font-weight>",
						/*7*/		"<font-weight=500>\u2077</font-weight>",
						/*8*/		"<font-weight=500>\u2078</font-weight>",
						/*9*/		"<font-weight=500>\u2079</font-weight>",
						/*10*/		"<font-weight=500>\u00B9\u2070</font-weight>",
						/*11*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*12*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*13*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*14*/		"<font-weight=500>\u00B9\u00B9</font-weight>",
						/*15*/		"<font-weight=500>\u00B9\u00B9</font-weight>"
								};

	private int unitIndex = 16;

	private Animation ani;

	//practical unit change
	private string[] practicalUnit ={
						/*-15*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-12*/		"<font-weight=800>picometers (pm)</font-weight>",
						/*-11*/		"<font-weight=800>picometers (pm)</font-weight>",
						/*-10*/		"<font-weight=800>picometers (pm)</font-weight>",
						/*-9*/		"<font-weight=800>nanometers (nm)</font-weight>",
						/*-8*/		"<font-weight=800>nanometers (nm)</font-weight>",
						/*-7*/		"<font-weight=800>nanometers (nm)</font-weight>",
						/*-6*/		"<font-weight=800>micrometers (\u00B5m)</font-weight>",
						/*-5*/		"<font-weight=800>micrometers (\u00B5m)</font-weight>",
						/*-4*/		"<font-weight=800>micrometers (\u00B5m)</font-weight>",
						/*-3*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-2*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-1*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*0*/		"<font-weight=800>meters (m)</font-weight>",
						/*1*/		"<font-weight=800>meters (m)</font-weight>",
						/*2*/		"<font-weight=800>meters (m)</font-weight>",
						/*3*/		"<font-weight=800>kilometers (km)</font-weight>",
						/*4*/		"<font-weight=800>kilometers (km)</font-weight>",
						/*5*/		"<font-weight=800>kilometers (km)</font-weight>",
						/*6*/		"<font-weight=800>megameters (Mm)</font-weight>",
						/*7*/		"<font-weight=800>megameters (Mm)</font-weight>",
						/*8*/		"<font-weight=800>megameters (Mm)</font-weight>",
						/*9*/		"<font-weight=800>gigameters (Gm)</font-weight>",
						/*10*/		"<font-weight=800>gigameters (Gm)</font-weight>",
						/*11*/		"<font-weight=800>gigameters (Gm)</font-weight>",
						/*12*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*15*/		"<font-weight=800>millimeters (mm)</font-weight>"
								};
	private string[] worldTitle ={
						/*-15*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-12*/		"<font-weight=800>picometer (pm)</font-weight>",
						/*-11*/		"<font-weight=800>picometer (pm)</font-weight>",
						/*-10*/		"Chlorine Atom",
						/*-9*/		"Isopropyl Alcohol",
						/*-8*/		"Antibody",
						/*-7*/		"COVID",
						/*-6*/		"Mitochondria",
						/*-5*/		"Pollen",
						/*-4*/		"Paramecium",
						/*-3*/		"Snowflake",
						/*-2*/		"White Oak Acorn",
						/*-1*/		"Robin",
						/*0*/		"Human",
						/*1*/		"Right Whale",
						/*2*/		"Boat",
						/*3*/		"Tantalus Asteroid",
						/*4*/		"Eros Asteroid",
						/*5*/		"Agamemnon",
						/*6*/		"Haumea",
						/*7*/		"Earth",
						/*8*/		"Jupiter",
						/*9*/		"Sun",
						/*10*/		"<font-weight=800>gigameter (Gm)</font-weight>",
						/*11*/		"<font-weight=800>gigameter (Gm)</font-weight>",
						/*12*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*15*/		"<font-weight=800>millimeters (mm)</font-weight>"
								};

	private bool isUnitChangeAniPlay;
	private bool isUnitRight;
	private bool isUnitLeft;

	public GameObject practicalUnitObject;
	public GameObject worldTitleObject;

	public GameObject signalHubObject;
	SignalHub signalHub;

	// Start is called before the first frame update
	void Start()
    {
        decimalScript = GameObject.Find("StandNotationScript");
        decimalMove = decimalScript.GetComponent<DecimalMove_S>();
        ani= transform.GetComponent<Animation>();
		practicalUnitObject = GameObject.Find("PracticalUnit");
		worldTitleObject = GameObject.Find("WorldTitle2");

		signalHubObject = GameObject.Find("SignalHub");
		signalHub = signalHubObject.GetComponent<SignalHub>();
	}

    // Update is called once per frame
    void Update()
    {
		//for this unit change part. it is working. but it could be in the DecimalMove_S script.
		//the reason it is here is because made a mistake about using event at the end of decimal move animation to trigger the unit change animation. 
		//but there are things need to be done at the end of decimal move animation, for example, to make all holders back to right positions.
		//so add event solution is not good. 
		//so moved everything to the update function. it could be moved back to decimalmove_s script if have time.

		/*if(decimalMove.signalFromDecimal2UnitChange)
        {
			decimalMove.signalFromDecimal2UnitChange = false;
			if(decimalMove.signalFromDecimalLeft2UnitChange && decimalMove.currentWorldIndex % 3 == 0)
            {
					decimalMove.signalFromDecimalLeft2UnitChange = false;
					decimalMove.indexDecimal = decimalMove.indexDecimal + 3;
					decimalMove.dummyHolders = decimalMove.dummyHolders - 3;
					ani.Play("UnitChangeRight");
					isUnitChangeAniPlay = true;
					isUnitRight = true;				
			}
			if (decimalMove.signalFromDecimalRight2UnitChange && decimalMove.currentWorldIndex % 3 == 1)
            {
				decimalMove.signalFromDecimalRight2UnitChange = false;
				decimalMove.indexDecimal = decimalMove.indexDecimal - 3;
				decimalMove.dummyHolders = decimalMove.dummyHolders + 3;
				ani.Play("UnitChangeLeft");
				isUnitChangeAniPlay = true;
				isUnitLeft = true;
			}
		}*/

		if (signalHub.downSignalFromScale2Unit)
		{
			signalHub.downSignalFromScale2Unit = false;	
			
			decimalMove.signalFromDecimalLeft2UnitChange = false;
				decimalMove.indexDecimal = decimalMove.indexDecimal + 3;
				decimalMove.dummyHolders = decimalMove.dummyHolders - 3;
				ani.Play("UnitChangeRight");
				isUnitChangeAniPlay = true;
				isUnitRight = true;
		}
		if (signalHub.upSignalFromScale2Unit)
		{
			signalHub.upSignalFromScale2Unit = false;
			decimalMove.signalFromDecimalRight2UnitChange = false;
				decimalMove.indexDecimal = decimalMove.indexDecimal - 3;
				decimalMove.dummyHolders = decimalMove.dummyHolders + 3;
				ani.Play("UnitChangeLeft");
				isUnitChangeAniPlay = true;
				isUnitLeft = true;
		}
	

		if (isUnitChangeAniPlay && !ani.IsPlaying("UnitChangeRight") && !ani.IsPlaying("UnitChangeLeft"))
        {
			isUnitChangeAniPlay = false;

			GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("StandNotationAni");
			GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, decimalMove.transform.position, Quaternion.identity);
			newVisableEntitiesHolder.transform.parent = decimalMove.GetComponent<Transform>();

			if (isUnitRight)
			{
				for (int i = (decimalMove.dummyHolders + 3); i < (decimalMove.dummyHolders + 15); i++)//had dummyHolders--, so +1 here
				{
					print(i);
					//numbers move up along the holders
					decimalScript.transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
					decimalMove.transform.GetChild(1).GetChild(0).GetChild(i - 3).transform;
				}

				isUnitRight = false;
			}
			if (isUnitLeft)
			{
				for (int i = (decimalMove.dummyHolders - 3); i < (decimalMove.dummyHolders + 9); i++)//had dummyHolders--, so +1 here
				{
					print(i);
					//numbers move up along the holders
					decimalMove.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(i).GetChild(0).transform.parent =
					decimalMove.GetComponent<Transform>().GetChild(1).GetChild(0).GetChild(i + 3).transform;
				}

				isUnitLeft = false;
			}

			decimalMove.GetComponent<Transform>().GetChild(0).GetChild(0).GetChild(decimalMove.posDecimal).GetChild(0).transform.parent =
			decimalMove.GetComponent<Transform>().GetChild(1).GetChild(0).GetChild(decimalMove.posDecimal).transform;

			Destroy(decimalMove.transform.GetChild(0).gameObject);

			//signalHub.unitLeftAniDone = true;
			//signalHub.unitRightAniDone = true;
			signalHub.currentProcessDone = true;
			//turn off all the trigger
			signalHub.exponentDownAniDone = false;
			signalHub.exponentUpAniDone = false;
			signalHub.decimalLeftAniDone = false;
			signalHub.decimalRightAniDone = false;
			signalHub.scaleDownAniDone = false;
			signalHub.scaleUpAniDone = false;
		}
    }

    public void numberChangeRight()
    {
        indexDecimal = decimalMove.indexDecimal;
        //indexDecimal--;
        if (indexDecimal <= index2LeftCoe )   
        {
            transform.GetChild(0).GetChild(index1Holder).GetChild(0).gameObject.SetActive(false);
        }
       
        else if(indexDecimal> index2LeftCoe )
        {
            transform.GetChild(0).GetChild(indexM2Holder).GetChild(0).gameObject.SetActive(true);
        }
    }

	public void unitChangeRight()
    {
		transform.GetChild(0).GetChild(index1Holder).GetChild(0).gameObject.SetActive(false);
		transform.GetChild(0).GetChild(indexM3Holder).GetChild(0).gameObject.SetActive(true);
		transform.GetChild(0).GetChild(indexM4Holder).GetChild(0).gameObject.SetActive(true);
	}
	public void unitChangeLeft()
	{
		transform.GetChild(0).GetChild(index1Holder).GetChild(0).gameObject.SetActive(false);
		transform.GetChild(0).GetChild(index2Holder).GetChild(0).gameObject.SetActive(false);
		transform.GetChild(0).GetChild(indexM1Holder).GetChild(0).gameObject.SetActive(false);
	}
	public void numberChangeLeft()
    {
        indexDecimal = decimalMove.indexDecimal;
        print(indexDecimal);
        if (indexDecimal > index2LeftCoe-1 )
        {
            transform.GetChild(0).GetChild(indexM1Holder).GetChild(0).gameObject.SetActive(false);
        }
        else if (indexDecimal <= index2LeftCoe-1)
        {
            transform.GetChild(0).GetChild(index2Holder).GetChild(0).gameObject.SetActive(true);
        }
    }
	public void practicalUnitChange()
    {
		practicalUnitObject.GetComponent<TextMeshProUGUI>().text = practicalUnit[decimalMove.currentWorldIndex-1];
	}

	public void WorldTitleChange()
	{
		worldTitleObject.GetComponent<TextMeshProUGUI>().text = worldTitle[decimalMove.currentWorldIndex-1];
	}
	/*
	public void SignalFromDecimalRight2UnitChange()
    {
		if(decimalMove.currentWorldIndex%3==1 && decimalMove.signalFromDecimalRight2UnitChange && decimalMove.signalFromDecimal2UnitChange)
        {
			decimalMove.indexDecimal = decimalMove.indexDecimal - 3;
			decimalMove.dummyHolders = decimalMove.dummyHolders + 3;
			ani.Play("UnitChangeLeft");
			isUnitChangeAniPlay = true;
			isUnitLeft = true;
        }
    }
	public void SignalFromDecimalLeft2UnitChange()
	{
		if (decimalMove.currentWorldIndex % 3 == 0 && decimalMove.signalFromDecimalLeft2UnitChange && decimalMove.signalFromDecimal2UnitChange)
		{
			decimalMove.indexDecimal = decimalMove.indexDecimal + 3;
			decimalMove.dummyHolders = decimalMove.dummyHolders - 3;
			ani.Play("UnitChangeRight");
			isUnitChangeAniPlay = true;
			isUnitRight = true;
		}
	}
	*/

	/*
    public void BoxTextDisappear()
    {
        leftBoxText.text = "";
        rightBoxText.text = "";
    }

    public void BoxTextappear()
    {
        leftBoxText.text = unitNameForBox[unitIndex];
        rightBoxText.text = unitNameForBox[unitIndex + 1];
    }

	public void CenterTextChange()
	{
		centerUnitText.text = unitNameForCenterUnit[unitIndex];
	}*/
}
