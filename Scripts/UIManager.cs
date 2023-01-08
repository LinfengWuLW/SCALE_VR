using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    private string[] exponentVR={
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
	private string[] coefficientVR={
						/*-15*/		"<font-weight=500>0.0</font-weight>",
						/*-14*/		"<font-weight=500>0.0</font-weight>",
						/*-13*/		"<font-weight=500>0.0</font-weight>",
						/*-12*/		"<font-weight=500>0.0</font-weight>",
						/*-11*/		"<font-weight=500>0.0</font-weight>",
						/*-10*/		"<font-weight=500>0.0</font-weight>",
						/*-9*/		"<font-weight=500>0.0</font-weight>",
						/*-8*/		"<font-weight=500>0.0</font-weight>",
						/*-7*/		"<font-weight=500>0.0</font-weight>",
						/*-6*/		"<font-weight=500>0.0</font-weight>",
						/*-5*/		"<font-weight=500>0.0</font-weight>",
						/*-4*/		"<font-weight=500>0.0</font-weight>",
						/*-3*/		"<font-weight=500>1.7</font-weight>",
						/*-2*/		"<font-weight=500>1.7</font-weight>",
						/*-1*/		"<font-weight=500>1.7</font-weight>",
						/*0*/		"<font-weight=500>1.7</font-weight>",
						/*1*/		"<font-weight=500>1.7</font-weight>",
						/*2*/		"<font-weight=500>1.7</font-weight>",
						/*3*/		"<font-weight=500>1.7</font-weight>",
						/*4*/		"<font-weight=500>1.7</font-weight>",
						/*5*/		"<font-weight=500>1.7</font-weight>",
						/*6*/		"<font-weight=500>1.7</font-weight>",
						/*7*/		"<font-weight=500>1.7</font-weight>",
						/*8*/		"<font-weight=500>1.7</font-weight>",
						/*9*/		"<font-weight=500>1.7</font-weight>",
						/*10*/		"<font-weight=500>1.7</font-weight>",
						/*11*/		"<font-weight=500>1.7</font-weight>",
						/*12*/		"<font-weight=500>1.7</font-weight>",
						/*13*/		"<font-weight=500>1.7</font-weight>",
						/*14*/		"<font-weight=500>1.7</font-weight>",
						/*15*/		"<font-weight=500>1.7</font-weight>"
								};
	
	private int entityIndex=16;
	
	public TextMeshProUGUI exponentText1;
	public TextMeshProUGUI exponentText2;
	public TextMeshProUGUI coefficientText3;
	
	private int textActiveIndex=0;
	private int textNotActiveIndex=1;
	
	private Animation ani;
	
	private bool scaleUpC=false;
	private bool scaleDownC=false;
	
	private bool isAction=false;

	public GameObject HMDInputObeject;
	HMDInputModule vrpnInput;

	public GameObject signalHubObject;
	SignalHub signalHub;


	public bool scaleUpUI=false;
	public bool scaleDownUI=false;
	
    void Start()
    {
        ani=transform.GetComponent<Animation>();
		
		//GameObject vrpnInputObeject=GameObject.FindGameObjectWithTag("Input");
		
		vrpnInput = HMDInputObeject.GetComponent<HMDInputModule>();

		signalHub =signalHubObject.GetComponent<SignalHub>();
	}

    // Update is called once per frame
    void Update()
    {
        scaleUpC= (vrpnInput.scaleUpC|vrpnInput.scaleUpHandMotion2Exp);		
		
		scaleDownC=(vrpnInput.scaleDownC|vrpnInput.scaleDownHandMotion2Exp);

		if (signalHub.upSignalFromHub2Exp && !isAction)//this is for simultaneous
		//if ((signalHub.upSignalFromHub2Exp || signalHub.upSignalFromDec2Exp) && !isAction)//this is for staggered animation
		//if ((Input.GetKeyDown(KeyCode.U)||scaleUpC)&& !isAction)
		{			
			signalHub.exponentUpAniDone = false;
			signalHub.upSignalFromHub2Exp = false;
			signalHub.upSignalFromDec2Exp = false;
			entityIndex++;
			
			textActiveIndex=entityIndex%2;
			textNotActiveIndex=(entityIndex+1)%2;
			if(textActiveIndex==1)
			{
				ani.Play("up_0_180");
				isAction = true;
				
				scaleUpC=false;
				vrpnInput.scaleUpC=false;
			}
			if(textActiveIndex==0)
			{
				ani.Play("up_180_360");
				isAction = true;
				
				scaleUpC=false;
				vrpnInput.scaleUpC=false;
			}
		}

		if (signalHub.downSignalFromHub2Exp && !isAction)//this is for simultaneous
		//if ((signalHub.downSignalFromHub2Exp || signalHub.downSignalFromDec2Exp) && !isAction)//this is for staggered animation
		//if ((Input.GetKeyDown(KeyCode.D)||scaleDownC) && !isAction)
		{
			signalHub.exponentDownAniDone = false;
			signalHub.downSignalFromHub2Exp = false;
			signalHub.downSignalFromDec2Exp = false;

			entityIndex--;
			
			textActiveIndex=entityIndex%2;
			textNotActiveIndex=(entityIndex+1)%2;
			if(textActiveIndex==1)
			{
				ani.Play("down_0_180");
				isAction = true;
				
				scaleDownC=false;
				vrpnInput.scaleDownC=false;
			}
			if(textActiveIndex==0)
			{
				ani.Play("down_180_360");
				isAction = true;
				
				scaleDownC=false;
				vrpnInput.scaleDownC=false;
			}
		}
		
		if (isAction && ( !ani.IsPlaying("up_0_180") && !ani.IsPlaying("up_180_360") &&!ani.IsPlaying("down_0_180") && !ani.IsPlaying("down_180_360") ) )
		{
			isAction = false;

			//try to fix the double click problem
			//set the signal to false after everything is done
			//so the scaling won't be triggered until next signal
			scaleDownC = false;
			scaleUpC = false;

			signalHub.exponentUpAniDone = true;
			signalHub.exponentDownAniDone = true;
		}
    }
	
	public void ExponentChange()
	{
		transform.GetChild(textNotActiveIndex).gameObject.SetActive(false);
		if(textActiveIndex==1)
		{
			exponentText2.text=exponentVR[entityIndex-1];
		}
		if(textActiveIndex==0)
		{
			exponentText1.text=exponentVR[entityIndex-1];
		}
		transform.GetChild(textActiveIndex).gameObject.SetActive(true);
	}
	public void CoefficientChange()
	{		
		//coefficientText3.text=coefficientVR[entityIndex-1];
	}
	
	public void ScaledUpInfoFromUItoScaling()
	{
		scaleUpUI=true;
	}
	
	public void ScaledDownInfoFromUItoScaling()
	{
		scaleDownUI=true;
	}
}
