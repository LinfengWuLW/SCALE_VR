using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecimalMoveAni : MonoBehaviour
{
    private int indexM2Holder=22;
    private int indexM1Holder = 21;

    private int index2Holder = 19;
    private int index1Holder = 20;

    private int indexDecimal;

    private int index2LeftCoe = 17;

    public GameObject decimalScript;
    DecimalMove decimalMove;

    // Start is called before the first frame update
    void Start()
    {
        decimalScript = GameObject.Find("DecimalMoveScriptHolder");
        decimalMove = decimalScript.GetComponent<DecimalMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void numberChangeRight()
    {
        indexDecimal = decimalMove.indexDecimal;
        //indexDecimal--;
        if (indexDecimal <= index2LeftCoe - 1)   
        {
            transform.GetChild(0).GetChild(index1Holder).GetChild(0).gameObject.SetActive(false);
        }
       
        else if(indexDecimal> index2LeftCoe - 1)
        {
            transform.GetChild(0).GetChild(indexM2Holder).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void numberChangeLeft()
    {
        indexDecimal = decimalMove.indexDecimal;
        print(indexDecimal);
        if (indexDecimal >= index2LeftCoe-1 )
        {
            transform.GetChild(0).GetChild(indexM1Holder).GetChild(0).gameObject.SetActive(false);
        }
        else if (indexDecimal < index2LeftCoe-1)
        {
            transform.GetChild(0).GetChild(index2Holder).GetChild(0).gameObject.SetActive(true);
        }
    }
}
