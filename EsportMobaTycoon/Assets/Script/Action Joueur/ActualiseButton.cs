using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ActualiseButton : MonoBehaviour
{
    public List<GameObject> i_button;

    public Sprite i_select;
    public Sprite i_dontSelect;

    public Color i_textColor;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSelectByIndexPC(int index)
    {
        for (int i = 0; i < i_button.Count; i++)
        {
            i_button[i].GetComponent<Image>().sprite = i_dontSelect;
            i_button[i].GetComponentInChildren<TMP_Text>().color = i_textColor;
        }
        i_button[index].GetComponent<Image>().sprite = i_select;
        i_button[index].GetComponentInChildren<TMP_Text>().color = Color.white;
    }

    public void ButtonSelectByIndexPlayer(int index)
    {
        for(int i = 0;i < i_button.Count; i++)
        {
            i_button[i].GetComponent<Image>().enabled = true;
            i_button[i].GetComponentInChildren<Image>().enabled = false;
        }
        i_button[index].GetComponent<Image>().enabled = false;
        i_button[index].GetComponentInChildren<Image>().enabled = true;
    }
}
