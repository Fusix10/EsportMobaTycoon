using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTexture : MonoBehaviour
{
    // Start is called before the first frame update
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
    
    public void change()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2 (652,189);
    }
    
    public void changeBack()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2 (625,176);
    }
}
