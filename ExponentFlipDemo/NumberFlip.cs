using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberFlip : MonoBehaviour
{

    private int numberIndex = 10;
    public Text numberText1;
    public Text numberText2;

    private int textActiveIndex = 0;
    private int textNotActiveIndex = 1;

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
        textActiveIndex = numberIndex % 2;
        textNotActiveIndex = (numberIndex + 1) % 2;
        
        if(textActiveIndex==1)
        {
            ani.Play("flipUp");
        }

        if (textActiveIndex == 0)
        {
            ani.Play("flipUp180_360");
        }
        //numberText.text = numberIndex.ToString();
        //ani.Play("flipUp2show");
    }

    public void DownButtonPress()
    {
        numberIndex--;
        textActiveIndex = numberIndex % 2;
        textNotActiveIndex = (numberIndex + 1) % 2;

        if (textActiveIndex == 1)
        {
            ani.Play("flipDown");
        }

        if (textActiveIndex == 0)
        {
            ani.Play("flipDown180_360");
        }
        
    }

    public void numberChange()
    {

        transform.GetChild(textNotActiveIndex).gameObject.SetActive(false);

        if (textActiveIndex == 1)
        {
            numberText2.text = (numberIndex).ToString();
        }

        if (textActiveIndex == 0)
        {
            numberText1.text = (numberIndex).ToString();
        }

        transform.GetChild(textActiveIndex).gameObject.SetActive(true);
    }

}
