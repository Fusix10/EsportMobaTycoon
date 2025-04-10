using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBase : MonoBehaviour, IPopUp
{
    [SerializeField] private Canvas pPopUpCanva;
    public Canvas PopUpCanva
    {
        get { return pPopUpCanva; }
        set { pPopUpCanva = value; }
    }

    void Start()
    {
        if (PopUpCanva == null)
        {
            Debug.LogError("Canvas prefab is not assigned.");
        }
        else
        {
            PopUpCanva.gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void Display()
    {
        PopUpCanva.gameObject.SetActive(true);
    }

    public void Hide()
    {
        PopUpCanva.gameObject.SetActive(false);
    }
}
