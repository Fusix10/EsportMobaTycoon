using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{

    public GameObject PanelStart;
    public GameObject PanelOptions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOptions()
    {
        PanelOptions.SetActive(true);
        PanelStart.SetActive(false);
    }
}
