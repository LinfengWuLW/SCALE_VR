using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitChange : MonoBehaviour
{

    public TextMeshProUGUI leftBoxText;
    public TextMeshProUGUI rightBoxText;

	private Animation ani;

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

	private bool isScaleAction=false;

	private int unitIndex=16;
	// Start is called before the first frame update
	void Start()
    {
		//ani = transform.GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update()
    {
		/*if ((Input.GetKeyDown(KeyCode.W) ) && !isScaleAction)
        {
			unitIndex++;

			ani.Play("UnitChangeRight");
			isScaleAction = true;
		}
		if ((Input.GetKeyDown(KeyCode.Q)) && !isScaleAction)
		{
			unitIndex--;

			ani.Play("UnitChangeLeft");
			isScaleAction = true;
		}
		if (isScaleAction && (!ani.IsPlaying("UnitChangeRight") && !ani.IsPlaying("UnitChangeLeft")))
        {
			isScaleAction = false;
        }*/
	}

    public void BoxTextDisappear()
    {
        leftBoxText.text = "";
        rightBoxText.text = "";
    }

    public void BoxTextappear()
    {
		leftBoxText.text = unitNameForBox[unitIndex];
		rightBoxText.text = unitNameForBox[unitIndex+1];
	}
}
