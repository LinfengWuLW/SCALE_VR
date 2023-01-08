using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Keys:
 - s: next scene
*/


public class SceneController : MonoBehaviour {

	public GameObject PanelOne;
	bool OneActive = false;
	public GameObject PanelTwo;
	bool TwoActive = false;
	public GameObject PanelThree;
	bool ThreeActive = false;
	public GameObject PanelFour;
	bool FourActive = false;
	public GameObject PanelFive;
	bool FiveActive = false;
	public GameObject PanelSix;
	bool SixActive = false;

	public GameObject[] WorldTitles;
	bool WorldTitleActive = false;

	public GameObject FloatingPlanets;
	bool FloatingPlanetsActive = false;
	public GameObject RestingPlanets;
	bool RestingPlanetsActive = false;
	public GameObject GroundPlanets;
	bool GroundPlanetsActive = false;

	public GameObject[] Modals;
	public GameObject[] InfoPanels;
	public GameObject ProgressPanelGuides;
	public GameObject StackingBox;
	public GameObject[] StackingBoxPanels;

	int i = 0;
	int j = 0;
	int k = 0;
	bool ProgressPanelGuidesAreActive = false;
	bool StackingBoxIsActive = false;

	// Use this for initialization
	void Start () {

		bool show = false;
		//PanelOne = GameObject.FindWithTag("Panel 1");

		print("Scene Controller activated");
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;

		print(sceneName);
		
		**/
		
		if(Input.GetKey("i")) {
			print("screenshot captured! I hope");
			ScreenCapture.CaptureScreenshot("Screenshots/screenshot.png");
		}

		// Navigation Panel Animation
		if(Input.GetKeyDown(".")) {
			if(i < 19){
				Modals[i].SetActive(false);
				Modals[i+1].SetActive(true);
				i++;
			}
		}
		if(Input.GetKeyDown(",")) {
			if(i > 0){
				Modals[i].SetActive(false);
				Modals[i-1].SetActive(true);
				i--;
			}
		}
		// Info Panel Animation
		if (Input.GetKeyDown("1"))
		{
			if (j < 19)
			{
				InfoPanels[j].SetActive(false);
				InfoPanels[j + 1].SetActive(true);
				j++;
			}
		}
		if (Input.GetKeyDown("2"))
		{
			if (j > 0)
			{
				InfoPanels[j].SetActive(false);
				InfoPanels[j - 1].SetActive(true);
				j--;
			}
		}

		if (Input.GetKeyDown("3"))
		{
			if (!ProgressPanelGuidesAreActive) {
				ProgressPanelGuides.SetActive(true);
				ProgressPanelGuidesAreActive = true;
			} else
            {
				ProgressPanelGuides.SetActive(false);
				ProgressPanelGuidesAreActive = false;
			}
		}

		if (Input.GetKeyDown("4"))
		{
			if (!StackingBoxIsActive)
			{
				StackingBox.SetActive(true);
				StackingBoxIsActive = true;
			}
			else
			{
				StackingBox.SetActive(false);
				StackingBoxIsActive = false;
			}
		}

		// Stacking Panels
		if (Input.GetKeyDown("5"))
		{
			if (k < 19)
			{
				StackingBoxPanels[k].SetActive(false);
				StackingBoxPanels[k + 1].SetActive(true);
				k++;
			}
		}
		if (Input.GetKeyDown("6"))
		{
			if (k > 0)
			{
				StackingBoxPanels[k].SetActive(false);
				StackingBoxPanels[k - 1].SetActive(true);
				k--;
			}
		}

		/*


		if (Input.GetKey("z")) {
			SceneManager.LoadScene ("Design");
		}
		if (Input.GetKey("c") && sceneName == "Design") {
			SceneManager.LoadScene ("Design Underlay");
		} else if (Input.GetKey("c") && sceneName == "Design Underlay"){
			SceneManager.LoadScene ("Design");
		}
		if (Input.GetKey("x")) {
			SceneManager.LoadScene ("Design 2");
		}

		//Panel One
		if (Input.GetKeyDown("1") && !OneActive){
			PanelOne.SetActive(true);
			OneActive = true;
		} else if(Input.GetKeyDown("1") && OneActive) {
			PanelOne.SetActive(false);
			OneActive = false;
		}

		/*
		if (Input.GetKey("q")){
			PanelOverlay.SetActive(true);
		} else {
			PanelOverlay.SetActive(false);
		}
		*

		/*
		//Panel Two
		if (Input.GetKeyDown("2") && !TwoActive){
			PanelTwo.SetActive(true);
			TwoActive = true;
		} else if(Input.GetKeyDown("2") && TwoActive) {
			PanelTwo.SetActive(false);
			TwoActive = false;
		}

		//Panel Three
		if (Input.GetKeyDown("3") && !ThreeActive){
			PanelThree.SetActive(true);
			ThreeActive = true;
		} else if(Input.GetKeyDown("3") && ThreeActive) {
			PanelThree.SetActive(false);
			ThreeActive = false;
		}

		//Panel Four
		if (Input.GetKeyDown("4") && !FourActive){
			PanelFour.SetActive(true);
			FourActive = true;
		} else if(Input.GetKeyDown("4") && FourActive) {
			PanelFour.SetActive(false);
			FourActive = false;
		}

		//Panel Five
		if (Input.GetKeyDown("5") && !FiveActive){
			PanelFive.SetActive(true);
			FiveActive = true;
		} else if(Input.GetKeyDown("5") && FiveActive) {
			PanelFive.SetActive(false);
			FiveActive = false;
		}

		//Panel Six
		if (Input.GetKeyDown("6") && !SixActive){
			PanelSix.SetActive(true);
			SixActive = true;
		} else if(Input.GetKeyDown("6") && SixActive) {
			PanelSix.SetActive(false);
			SixActive = false;
		}

		//World Titles
		if (Input.GetKeyDown("7") && !WorldTitleActive){
			foreach (GameObject WorldTitle in WorldTitles){
				WorldTitle.SetActive(true);
			}
			WorldTitleActive = true;
		} else if(Input.GetKeyDown("7") && WorldTitleActive) {
			foreach (GameObject WorldTitle in WorldTitles){
				WorldTitle.SetActive(false);
			}
			WorldTitleActive = false;
		}

		//Floating Planets
		if (Input.GetKeyDown("8") && !FloatingPlanetsActive){
			FloatingPlanets.SetActive(true);
			FloatingPlanetsActive = true;
		} else if(Input.GetKeyDown("8") && FloatingPlanetsActive) {
			FloatingPlanets.SetActive(false);
			FloatingPlanetsActive = false;
		}
		//Resting Planets
		if (Input.GetKeyDown("9") && !RestingPlanetsActive){
			RestingPlanets.SetActive(true);
			RestingPlanetsActive = true;
		} else if(Input.GetKeyDown("9") && RestingPlanetsActive) {
			RestingPlanets.SetActive(false);
			RestingPlanetsActive = false;
		}
		//Ground Planets
		if (Input.GetKeyDown("0") && !GroundPlanetsActive){
			GroundPlanets.SetActive(true);
			GroundPlanetsActive = true;
		} else if(Input.GetKeyDown("0") && GroundPlanetsActive) {
			GroundPlanets.SetActive(false);
			GroundPlanetsActive = false;
		}
		**/


	}
}
