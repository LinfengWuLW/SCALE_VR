using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeSurfaceNF : MonoBehaviour
{

    private int numberIndex = 10;

    public Text numberText1;
    public Text numberText2;
    public Text numberText3;

    private int aniActiveIndex = 0;
    private int aniNotActiveIndex1 = 1;
    private int aniNotActiveIndex2 = 2;

    private int textActiveIndex = 0;
    private int textNotActiveIndex1 = 1;
    private int textNotActiveIndex2 = 2;

    private int dummyLargeNumber = 99999;

    private Animation ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = transform.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpButtonPress()
    {
        numberIndex++;

        aniActiveIndex = numberIndex % 3;
        aniNotActiveIndex1 = (numberIndex + 1) % 3;
        aniNotActiveIndex2 = (numberIndex + 2) % 3;

        textActiveIndex = (numberIndex+2) % 3;
        textNotActiveIndex1 = (numberIndex + 3) % 3;
        textNotActiveIndex2 = (numberIndex + 4) % 3;

        if (textActiveIndex == 1)
        {
            numberText2.text = (numberIndex).ToString();
        }

        if (textActiveIndex == 0)
        {
            numberText1.text = (numberIndex).ToString();
        }

        if (textActiveIndex == 2)
        {
            numberText3.text = (numberIndex).ToString();
        }

       

        if (aniActiveIndex == 0)
        {
            ani.Play("Up_120_240");
        }

        if (aniActiveIndex == 1)
        {
            ani.Play("Up_240_360");
        }

        if (aniActiveIndex == 2)
        {
            ani.Play("Up_0_120");
        }
        //numberText.text = numberIndex.ToString();
        //ani.Play("flipUp2show");
    }

    public void DownButtonPress()
    {
        numberIndex--;
        
        aniActiveIndex = (dummyLargeNumber- numberIndex) % 3;
        aniNotActiveIndex1 = (dummyLargeNumber- numberIndex + 1) % 3;
        aniNotActiveIndex2 = (dummyLargeNumber- numberIndex + 2) % 3;

       /* textActiveIndex = (dummyLargeNumber-numberIndex + 2) % 3;
        textNotActiveIndex1 = (dummyLargeNumber-numberIndex + 3) % 3;
        textNotActiveIndex2 = (dummyLargeNumber- numberIndex + 4) % 3;
       */

        textActiveIndex = (numberIndex + 2) % 3;
        textNotActiveIndex1 = (numberIndex + 3) % 3;
        textNotActiveIndex2 = (numberIndex + 4) % 3;

        if (textActiveIndex == 1)
        {
            numberText2.text = (numberIndex).ToString();
        }

        if (textActiveIndex == 0)
        {
            numberText1.text = (numberIndex).ToString();
        }

        if (textActiveIndex == 2)
        {
            numberText3.text = (numberIndex).ToString();
        }



        if (aniActiveIndex == 0)
        {
            ani.Play("Down_0_120");
        }

        if (aniActiveIndex == 1)
        {
            ani.Play("Down_120_240");
        }

        if (aniActiveIndex == 2)
        {
            ani.Play("Down_240_360");
        }

    }

    public void numberChange3SF()
    {

        transform.GetChild(textNotActiveIndex1).gameObject.SetActive(false);
        transform.GetChild(textNotActiveIndex2).gameObject.SetActive(false);

    }

    public void numberAppear3SF()
    {
        transform.GetChild(textActiveIndex).gameObject.SetActive(true);
    }

}
