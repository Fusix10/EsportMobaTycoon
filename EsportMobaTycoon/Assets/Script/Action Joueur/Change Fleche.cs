using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFleche : MonoBehaviour
{
    public TMP_Text i_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GetComponent<Button>().currentSelectionState)
        {
            change();
        }
        else
        {
            changeBack();
        }*/
    }
    
    public void change(bool isOn)
    {
        if (isOn)
        {
            i_text.text = "<";
        }else if (!isOn)
        {
            i_text.text = ">";
        }
    }
    
}
