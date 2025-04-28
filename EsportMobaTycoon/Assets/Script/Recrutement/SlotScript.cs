using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [Header("Info")]
    public TMP_Text i_name;
    public Image i_face;
    public Image i_hair;

    [Header("Panel")]
    public GameObject i_panelRole;
    public GameObject i_panelRoleActivate;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void InitInfo(PlayerData playerData)
    {
        SwitchPanel(true);
        i_face.sprite = playerData.i_skin.i_faceSitting;
        i_hair.sprite = playerData.i_skin.i_hairSitting;
        i_name.text = playerData.i_name;
    }

    public void CopyInfo(Sprite face, Sprite hair, string name)
    {
        SwitchPanel(true);
        i_face.sprite = face;
        i_hair.sprite = hair;
        i_name.text = name;
    }

    public void SwitchPanel(bool Panel)
    {
        if (Panel == true)
        {
            i_panelRole.SetActive(false);
            i_panelRoleActivate.SetActive(true);
        }
        else 
        {
            i_panelRole.SetActive(true);
            i_panelRoleActivate.SetActive(false);
        }
    }
}
