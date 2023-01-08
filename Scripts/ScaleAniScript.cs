using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleAniScript : MonoBehaviour
{
    public GameObject worldTitleObject;

    public GameObject signalHubObject;
    SignalHub signalHub;

	private string[] worldTitle ={
						/*-15*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*-12*/		"<font-weight=800>picometers (pm)</font-weight>",
						/*-11*/		"<font-weight=800>picometers (pm)</font-weight>",
						/*-10*/		"Water Molecule World",
						/*-9*/		"Insulin Molecule World",
						/*-8*/		"Antibody World",
						/*-7*/		"COVID-19 World",
						/*-6*/		"Mitochondria World",
						/*-5*/		"White Blood Cell World",
						/*-4*/		"Paramecium World",
						/*-3*/		"Ant World",
						/*-2*/		"White Oak Acorn World",
						/*-1*/		"American Robin World",
						/*0*/		"Human World",
						/*1*/		"Right Whale World",
						/*2*/		"American Football Field World",
						/*3*/		"Brooklyn Bridge World",
						/*4*/		"Halley\u2019s Comet Nucleus World",
						/*5*/		"Grand Canyon World",
						/*6*/		"Texas World",
						/*7*/		"Earth World",
						/*8*/		"Jupiter World",
						/*9*/		"Sun World",
						/*10*/		"<font-weight=800>gigameters (Gm)</font-weight>",
						/*11*/		"<font-weight=800>gigameters (Gm)</font-weight>",
						/*12*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*13*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*14*/		"<font-weight=800>millimeters (mm)</font-weight>",
						/*15*/		"<font-weight=800>millimeters (mm)</font-weight>"
								};
	void Start()
    {
        worldTitleObject = GameObject.Find("WorldTitle2");

        signalHubObject = GameObject.Find("SignalHub");
        signalHub = signalHubObject.GetComponent<SignalHub>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void WorldTitleChange()
    {
        worldTitleObject.GetComponent<TextMeshProUGUI>().text = worldTitle[signalHub.currentWorldIndex - 1];
    }
}
