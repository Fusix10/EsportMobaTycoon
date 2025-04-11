using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionJoueur : MonoBehaviour
{
    public GameObject i_panelStat;
    public GameObject i_panelAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanelStat(bool toogle)
    {
        i_panelStat.SetActive(toogle);
        i_panelAction.SetActive(false);
    }
}
