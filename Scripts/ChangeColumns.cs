using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColumns : MonoBehaviour
{

    public GameObject Plain;
    public GameObject Corners;
    public GameObject Path;
    public GameObject Forest;
    public GameObject Seam;
    public GameObject Chart;
    public GameObject Backdrop;
    public GameObject Cage;
    public GameObject GlowCage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            Plain.SetActive(true);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            Plain.SetActive(false);
            Corners.SetActive(true);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if(Input.GetKeyDown("p"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(true);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("f"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(true);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("5"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(true);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("6"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(true);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("7"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(true);
            Cage.SetActive(false);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("8"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(true);
            GlowCage.SetActive(false);
        }
        if (Input.GetKeyDown("9"))
        {
            Plain.SetActive(false);
            Corners.SetActive(false);
            Path.SetActive(false);
            Forest.SetActive(false);
            Seam.SetActive(false);
            Chart.SetActive(false);
            Backdrop.SetActive(false);
            Cage.SetActive(false);
            GlowCage.SetActive(true);
        }
    }
}
