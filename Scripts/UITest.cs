using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITest : MonoBehaviour
{
    
	private string test="<font-weight=800>\u00B5m</font-weight>";

	public Text testText;
	public TextMeshProUGUI test2;

	// Start is called before the first frame update
    void Start()
    {
		test2.text=test;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
