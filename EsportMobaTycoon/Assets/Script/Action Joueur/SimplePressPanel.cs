using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimplePressPanel : MonoBehaviour
{
    public TMP_Text i_name;
    public Slider i_slider;
    public List<Image> i_lvl;
    public List<Image> i_Potentiel;

    public void InitStat(string name,float moral,int lvl, int potentiel)
    {
        CleanUp();
        i_name.text = name;
        i_slider.value = (moral/100);
        Debug.Log("le moral:" + moral);

        for (int i = 0; i < lvl; i++) 
        {
            i_lvl[i].color = Color.yellow;
        }

        for (int i = 0; i < potentiel; i++)
        {
            i_Potentiel[i].color = Color.yellow;
        }
    }

    public void CleanUp()
    {
        for (int i = 0; i < 5; i++)
        {
            i_lvl[i].color = Color.white;
        }

        for (int i = 0; i < 5; i++)
        {
            i_Potentiel[i].color = Color.white;
        }
    }
}
