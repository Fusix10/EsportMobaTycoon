using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionJoueur : MonoBehaviour
{
    public GameObject PanelStat;
    public GameObject PanelAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanelStat(bool Toogle)
    {
        PanelStat.SetActive(Toogle);
        PanelAction.SetActive(false);
    }
}
