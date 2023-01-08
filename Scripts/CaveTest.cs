using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for scaling animation
public class CaveTest : MonoBehaviour
{
	private Animation ani;

	public Transform entitiesHolder;

	private bool grow;
	private bool shrink;
	private bool isScaleAction;

	public GameObject HMDInputObeject;
	HMDInputModule vrpnInput;

	public GameObject UIManagerObeject;
	UIManager uiManager;
	
	private bool scaleUpUI=false;
	private bool scaleDownUI=false;
	
	//use the scale signal from controller directly
	private bool scaleUpC=false;
	private bool scaleDownC=false;
	
	private bool isStackAction=false;
	private bool isStack=false;
	private bool isClearStack=false;
	private int stackIndex=0;
	private int stackActiveIndex=0;

	//this variable represents the total number of the entities/worlds.
	int totalWorldsNumber=31;
	//WorldsHolder holds all the entities/worlds. W0,W9 are dummy holders. 

	int numberOfVisableWorlds=5;

	//this is the entity/world index the participant currently facing/at the most proper size.
	public int entityIndex=16;

	int numberOfVisableEntitiesHolder=1;

	//Vector3 newSmallEntityPosition = new Vector3(0.01f, 0.005f, 0);
	//Vector3 newLargeEntityPosition = new Vector3(1000, 500, 0);
	Vector3 newSmallEntityPosition = new Vector3(0, 0, 0);
	Vector3 newLargeEntityPosition = new Vector3(0, 0, 0);

	//stacking
	public Transform StackManager;
	private bool isStacking;
	private bool isStacked;

	//stack 0.1u
	//Vector3 newEntityPosition01u=new Vector3(0,0,0);
	//if stack next to the reference
	Vector3 newEntityPosition01u=new Vector3(0.5f,0,0);
	Vector3 addYdis01u=new Vector3(0,0.1f,0);

	//array to store positions and rotations of stacking
	//two dimention array, Vector3[29,9], 30 entities, 10 positions
	Vector3[,] stackingPos={
	/*-15*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-14*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-13*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-12*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-11*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-10*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-9*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-8*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-7*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-6*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-5*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-4*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-3*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-2*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-1*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*0*/	{new Vector3(0.7f,0.59f,0.5f),new Vector3(0.7f,0.59f,0.4f),new Vector3(0.7f,0.59f,0.3f),new Vector3(0.7f,0.59f,0.2f),new Vector3(0.7f,0.59f,0.1f),new Vector3(0.7f,0.59f,0),new Vector3(0.7f,0.59f,-0.1f),new Vector3(0.7f,0.59f,-0.2f),new Vector3(0.7f,0.59f,-0.3f),new Vector3(0.7f,0.59f,-0.4f)},
	/*1*/	{new Vector3(0,0.59f,-0.5f),new Vector3(0,0.59f,-0.4f),new Vector3(0,0.59f,-0.3f),new Vector3(0,0.59f,-0.2f),new Vector3(0,0.59f,-0.1f),new Vector3(0,0.59f,0),new Vector3(0,0.59f,0.1f),new Vector3(0,0.59f,0.2f),new Vector3(0,0.59f,0.3f),new Vector3(0,0.59f,0.4f)},
	/*2*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*3*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*4*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*5*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*6*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*7*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*8*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*9*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*10*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*11*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*12*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*13*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*14*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*15*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},

	};
	Vector3[,] stackingRot={
	/*-15*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-14*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-13*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-12*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-11*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-10*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-9*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-8*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-7*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-6*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-5*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*-4*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-3*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-2*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*-1*/	{new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)},
	/*0*/	{new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0),new Vector3(90,0,0)},
	/*1*/	{new Vector3(0,90,0),new Vector3(0,0,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0)},
	/*2*/	{new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0)},
	/*3*/	{new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0),new Vector3(0,90,0)},
	/*4*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*5*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*6*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*7*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*8*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*9*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*10*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*11*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*12*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*13*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*14*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},
	/*15*/	{new Vector3(0,0.05f,0),new Vector3(0,0.15f,0),new Vector3(0,0.25f,0),new Vector3(0,0.35f,0),new Vector3(0,0.45f,0),new Vector3(0,0.55f,0),new Vector3(0,0.65f,0),new Vector3(0,0.75f,0),new Vector3(0,0.85f,0),new Vector3(0,0.95f,0)},

	};

	public GameObject signalHubObject;
	SignalHub signalHub;

	public Transform stackingButton;

	void Start()
	{	
		uiManager=UIManagerObeject.GetComponent<UIManager>();
		vrpnInput = HMDInputObeject.GetComponent<HMDInputModule>();
		signalHub = signalHubObject.GetComponent<SignalHub>();
	}

	void Update()
	{		
		scaleUpUI=uiManager.scaleUpUI;	
		scaleDownUI=uiManager.scaleDownUI;
		
		//use the scale signal from controller directly
		scaleUpC = vrpnInput.upFromC2Scaling | vrpnInput.scaleUpHandMotion;

		//scaleDownC =vrpnInput.scaleDownC|vrpnInput.scaleDownHandMotion;
		scaleDownC = vrpnInput.downFromC2Scaling | vrpnInput.scaleDownHandMotion;

		//isStackAction =vrpnInput.isStackAction;
		isStackAction = stackingButton.GetComponent<StackingButton>().isStackAction;

		if (isStackAction && (!isStacking))
		{
			stackIndex++;
			stackActiveIndex = stackIndex % 2;
			if (stackActiveIndex == 1)
			{
				isStack = true;
				isClearStack = false;
			}
			else
			{
				isStack = false;
				isClearStack = true;
			}
		}
		
		vrpnInput.isStackAction=false;

		//use the signal from UI exponent , scale when the exponent rotation is done
		//if ((Input.GetKeyDown(KeyCode.D) || scaleDownUI ) && (!isScaleAction))

		if (signalHub.downSignalFromHub2Scale && (!isScaleAction))//this is for simultaneous
		//if ((signalHub.downSignalFromExp2Scale || signalHub.downSignalFromDec2Scale) && (!isScaleAction))//this is for staggered animation
		//if ((Input.GetKeyDown(KeyCode.D) || scaleDownC ) && (!isScaleAction))	
		{
			signalHub.downSignalFromDec2Scale = false;
			signalHub.downSignalFromExp2Scale = false;

			signalHub.downSignalFromHub2Scale = false;

			scaleDownUI =false;
			scaleDownC=false;
			vrpnInput.downFromC2Scaling = false;
			//vrpnInput.scaleDownHandMotion = false;

			if (entityIndex == 2)
			{
				print("no more scale down");
			}
			else
			{
				//check if stacked first, if true, clear stacked entities before scaling
				if(isStacked)
                {
					Destroy(StackManager.GetChild(0).gameObject);
					isClearStack = false;

					isStacked = false;
					stackIndex++;
				}
				//get the small entity from the EntitiesHolder
				GameObject newSmallEntityPre = entitiesHolder.GetChild(entityIndex - 3).GetChild(0).gameObject;

				//Instantiate the small entity
				GameObject newSmallEntity = Instantiate(newSmallEntityPre, newSmallEntityPosition, Quaternion.identity);

				//attach the small entity to the first (not default)
				newSmallEntity.transform.parent = transform.GetChild(numberOfVisableEntitiesHolder - 1).transform;
				newSmallEntity.transform.SetAsFirstSibling();

				ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
				//ani.Play("grow");
				ani.Play("grow2");

				grow = true;
				isScaleAction = true;

				//Instantiate the NewVisableEntitiesHolder
				GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("NewVisibleHolder");
				GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

				//numberOfVisableEntitiesHolder++;

				//attach the NewVisableEntitiesHolder to VisableHolder
				newVisableEntitiesHolder.transform.parent = transform;

				entityIndex--;
			} 
		}

		//if ( (Input.GetKeyDown(KeyCode.U)||  scaleUpUI ) && (!isScaleAction))

		//if ( (Input.GetKeyDown(KeyCode.U)||  scaleUpC ) && (!isScaleAction))

		if (signalHub.upSignalFromHub2Scale && (!isScaleAction))//this is for simultaneous
		//if ( (signalHub.upSignalFromExp2Scale || signalHub.upSignalFromDec2Scale) && (!isScaleAction))//this is for staggered animation
		{
			scaleUpUI=false;
			scaleUpC=false;
			vrpnInput.upFromC2Scaling = false;
			//vrpnInput.scaleUpHandMotion = false;

			signalHub.upSignalFromDec2Scale = false;
			signalHub.upSignalFromExp2Scale = false;

			signalHub.upSignalFromHub2Scale = false;

			if (entityIndex == totalWorldsNumber-1)
			{
				print("no more scale up");
			}
			else
			{
				//check if stacked first, if true, clear stacked entities before scaling
				if (isStacked)
				{
					Destroy(StackManager.GetChild(0).gameObject);
					isClearStack = false;

					isStacked = false;
					stackIndex++;
				}
				//get the large entity from the EntitiesHolder
				GameObject newLargeEntityPre = entitiesHolder.GetChild(entityIndex + 3).GetChild(1).gameObject;

				//Instantiate the large entity
				GameObject newLargeEntity = Instantiate(newLargeEntityPre, newLargeEntityPosition, Quaternion.identity);

				//attach the large entity to the last (default)
				newLargeEntity.transform.parent = transform.GetChild(numberOfVisableEntitiesHolder - 1).transform;

				ani = transform.GetChild(numberOfVisableEntitiesHolder - 1).GetComponent<Animation>();
				//ani.Play("shrink");
				ani.Play("shrink2");

				shrink = true;
				isScaleAction = true;

				GameObject newVisableEntitiesHolderPre = Resources.Load<GameObject>("NewVisibleHolder");
				GameObject newVisableEntitiesHolder = Instantiate(newVisableEntitiesHolderPre, transform.position, Quaternion.identity);

				//numberOfVisableEntitiesHolder++;

				newVisableEntitiesHolder.transform.parent = transform;

				entityIndex++;
			}
		}

		if (isScaleAction && ( !ani.IsPlaying("grow2") && !ani.IsPlaying("shrink2") ) )
		{
			//move all the Entities to the NewVisableEntitiesHolder
			for (int i = 0; i < 6; i++)
			{			
				transform.GetChild(0).GetChild(0).transform.parent =
				transform.GetChild(1).transform;
			}

			//destroy the old VisableEntitiesHolder
			DestroyImmediate(transform.GetChild(0).gameObject);

			isScaleAction = false;

			if (grow)
			{
				//destroy E5
				DestroyImmediate(transform.GetChild(0).GetChild(5).gameObject);

				grow = false;
			}

			if (shrink)
			{
				//destroy E1
				DestroyImmediate(transform.GetChild(0).GetChild(0).gameObject);

				shrink = false;
			}

			//try to fix the double click problem
			//set the signal to false after everything is done
			//so the scaling won't be triggered until next signal
			scaleDownC = false;
			scaleUpC = false;

			signalHub.scaleUpAniDone = true;
			signalHub.scaleDownAniDone = true;
		}

		if((Input.GetKeyDown(KeyCode.N)|| (isStackAction&& isStack) ) && (!isStacking) )
		{			
				StartCoroutine(ExecuteAfterTime01u(0.5f));
				isStack = false;		
		}		
		if( (Input.GetKeyDown(KeyCode.C) || (isStackAction&&isClearStack) )  && (!isStacking) )
		{		
			Destroy(StackManager.GetChild(0).gameObject);			
			isClearStack=false;

			isStacked = false;
		}
	}

	IEnumerator ExecuteAfterTime01u(float time)
	{
		isStacking = true;

		GameObject newStackingHolderPre = Resources.Load<GameObject>("NewStackingHolder");
		GameObject newStackingHolder = Instantiate(newStackingHolderPre, transform.position, Quaternion.identity);
		newStackingHolder.transform.parent = StackManager;

		GameObject newEntityPre =entitiesHolder.GetChild(entityIndex-1).GetChild(2).gameObject;

		for (int i=1;i<11;i++)
		{
			GameObject newEntity=Instantiate(newEntityPre, stackingPos[entityIndex-2,i-1],Quaternion.Euler(stackingRot[entityIndex-2,i-1]));
			newEntity.transform.parent=StackManager.GetChild(0).transform;
			yield return new WaitForSeconds(time);
		}

		isStacking = false;
		isStacked = true;
	}
}
